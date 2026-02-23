using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RescueTalk.Dispatcher.Migrations
{
    /// <inheritdoc />
    public partial class AddIncidentStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Incidents");
        }
    }
}
