using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RescueTalk.Dispatcher.Data;
using RescueTalk.Dispatcher.Services;
using RescueTalk.Dispatcher.Hubs; 

var builder = WebApplication.CreateBuilder(args);

// 1. Услуги
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddDbContext<RescueTalkDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. CORS конфигурация
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .SetIsOriginAllowed(_ => true)
              .AllowCredentials();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RescueTalk Dispatcher API", Version = "v1" });
});

builder.Services.AddScoped<IAmbulanceService, AmbulanceService>();
builder.Services.AddScoped<IIncidentService, IncidentService>();

var app = builder.Build();

// 3. Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RescueTalk Dispatcher API v1"));
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();
app.MapHub<AmbulanceHub>("/ambulanceHub");

// 4. Автоматично създаване на базата и СИЙДВАНЕ (Seeding)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var db = services.GetRequiredService<RescueTalkDbContext>();

        // Създава таблиците
        db.Database.EnsureCreated();

        // Вкарва твоите 8 линейки, ако базата е празна
        DbInitializer.Seed(db);

        Console.WriteLine("Базата данни е готова и данните са заредени.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Грешка при инициализация на БД: {ex.Message}");
    }
}

app.Run();