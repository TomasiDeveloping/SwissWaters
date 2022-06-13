using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class addUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApiUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_ApiUsers_ApiUserId",
                        column: x => x.ApiUserId,
                        principalTable: "ApiUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_ApiUserId",
                table: "UserClaims",
                column: "ApiUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "ApiUsers");

            migrationBuilder.DeleteData(
                table: "WatersTypes",
                keyColumn: "Id",
                keyValue: new Guid("18c7cde7-c2be-4ff1-836d-17c8802756a2"));

            migrationBuilder.DeleteData(
                table: "WatersTypes",
                keyColumn: "Id",
                keyValue: new Guid("39fbd2ab-b270-4569-8eb7-7b2e67b12000"));

            migrationBuilder.DeleteData(
                table: "WatersTypes",
                keyColumn: "Id",
                keyValue: new Guid("b722f533-ea3b-4c1a-b399-bfc32f0c384e"));

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
    }
}
