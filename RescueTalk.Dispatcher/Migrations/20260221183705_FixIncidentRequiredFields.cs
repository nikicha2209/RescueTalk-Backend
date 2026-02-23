using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RescueTalk.Dispatcher.Migrations
{
    /// <inheritdoc />
    public partial class FixIncidentRequiredFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Ambulances_AmbulanceId",
                table: "Incidents");

            migrationBuilder.AlterColumn<string>(
                name: "PatientPhone",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "AmbulanceId",
                table: "Incidents",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Ambulances_AmbulanceId",
                table: "Incidents",
                column: "AmbulanceId",
                principalTable: "Ambulances",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Ambulances_AmbulanceId",
                table: "Incidents");

            migrationBuilder.AlterColumn<string>(
                name: "PatientPhone",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AmbulanceId",
                table: "Incidents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Ambulances_AmbulanceId",
                table: "Incidents",
                column: "AmbulanceId",
                principalTable: "Ambulances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
