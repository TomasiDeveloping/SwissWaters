using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class fixWatersType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "WatersTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "WatersTypes",
                columns: new[] { "Id", "Identifier", "Name" },
                values: new object[] { new Guid("2b9193f3-5bd4-44fa-a7a1-1eedc9089874"), "RIVER", "Fluss" });

            migrationBuilder.InsertData(
                table: "WatersTypes",
                columns: new[] { "Id", "Identifier", "Name" },
                values: new object[] { new Guid("abfb48e1-2a4c-4950-9038-3f48ba0420fe"), "LAKE", "See" });

            migrationBuilder.InsertData(
                table: "WatersTypes",
                columns: new[] { "Id", "Identifier", "Name" },
                values: new object[] { new Guid("eacb08f2-f865-4bae-8539-abcf8b3101b7"), "STREAM", "Bach" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WatersTypes",
                keyColumn: "Id",
                keyValue: new Guid("2b9193f3-5bd4-44fa-a7a1-1eedc9089874"));

            migrationBuilder.DeleteData(
                table: "WatersTypes",
                keyColumn: "Id",
                keyValue: new Guid("abfb48e1-2a4c-4950-9038-3f48ba0420fe"));

            migrationBuilder.DeleteData(
                table: "WatersTypes",
                keyColumn: "Id",
                keyValue: new Guid("eacb08f2-f865-4bae-8539-abcf8b3101b7"));

            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "WatersTypes");
        }
    }
}
