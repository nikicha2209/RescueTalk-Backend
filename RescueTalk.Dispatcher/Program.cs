using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RescueTalk.Dispatcher.Data;
using RescueTalk.Dispatcher.Hubs;
using System;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<RescueTalkDbContext>(options =>
    options.UseSqlite("Data Source=rescuedb.db"));

//builder.WebHost.UseUrls("http://0.0.0.0:10000");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RescueTalk Dispatcher API", Version = "v1" });
});
builder.Services.AddSignalR();
builder.Services.AddRazorComponents(); 
builder.Services.AddServerSideBlazor();

//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(5019);
//});

var app = builder.Build();

// --- middleware ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RescueTalk Dispatcher API v1");
    });
}


app.MapHub<AmbulanceHub>("/ambulanceHub");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<RescueTalkDbContext>();
    db.Database.EnsureCreated();
}

app.Run();