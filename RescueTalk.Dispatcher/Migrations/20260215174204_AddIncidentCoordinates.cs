using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RescueTalk.Dispatcher.Migrations
{
    /// <inheritdoc />
    public partial class AddIncidentCoordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Incidents",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Incidents",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Incidents");
        }
    }
}
