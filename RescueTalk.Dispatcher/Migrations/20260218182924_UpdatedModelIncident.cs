using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RescueTalk.Dispatcher.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModelIncident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Incidents",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Incidents");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Incidents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incidents",
                table: "Incidents",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
        name: "PK_Incidents",
        table: "Incidents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Incidents");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Incidents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incidents",
                table: "Incidents",
                column: "Id");

        }
    }
}
