using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class addWatersType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WatersName",
                table: "Stations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "WatersTypeId",
                table: "Stations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "WatersTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatersTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stations_WatersTypeId",
                table: "Stations",
                column: "WatersTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_WatersTypes_WatersTypeId",
                table: "Stations",
                column: "WatersTypeId",
                principalTable: "WatersTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_WatersTypes_WatersTypeId",
                table: "Stations");

            migrationBuilder.DropTable(
                name: "WatersTypes");

            migrationBuilder.DropIndex(
                name: "IX_Stations_WatersTypeId",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "WatersName",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "WatersTypeId",
                table: "Stations");
        }
    }
}
