using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class saltAndPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "ApiUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Salt",
                table: "ApiUsers",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("06032f73-ef14-422f-96f0-6853beed2e18"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("0721fe5d-8207-44bd-b250-8e302e69946b"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("1b06caa3-c7e3-46a5-b1b9-660d2701e97b"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("23ba02aa-c3db-4a2a-9ae9-d10142ca120d"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("2760d42a-dd4c-4178-862e-72be9d76a0d6"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("3d0b8a43-710e-41c3-a639-34cb8ff180d3"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("42555469-aa40-4d6c-9dd1-22a9bb038221"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("439e5120-8fb7-4250-989f-d770f2e97d5e"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("45cbaebf-ec54-4959-8ec7-ea885bd4ce2b"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("5537caf0-b08b-4b97-b5eb-5673bda04896"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("5be6fa4b-552d-4dca-aa97-04833053555e"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("6ace043e-74f9-4d4f-a3e3-4ace1f697be8"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("76ee787c-959d-4891-b49b-b2595d4aeade"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("7ec82657-dac4-4a55-bb67-348a496789c5"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("7fa7f7ec-9de8-48f8-8bbf-1023f299e993"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("9a2ec3c7-aff0-4441-9469-0299dfb4ef9a"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("9d3a110f-8535-4dd0-ad92-21ff1831679f"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("9e00712c-8eac-4f7d-9e86-2a83de68eb17"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("a41bf4c3-e708-43ac-b4ea-a70ed155a706"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("c35ce2c3-67f7-43cc-91cd-3a0e982993cb"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("c6466559-e664-4476-9590-38ea80c94ce2"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("c9584dfa-b5e6-451e-a1f4-668cda9d2496"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("cfc407a1-77a2-40e6-835b-81c6474c170c"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("d7c52353-be8c-4e4a-99a0-914346d694b7"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("e0f60abc-7ac4-4baf-aa7d-f0e25b18a171"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("fded4d5c-589d-4e9a-98fc-c17cef412c9d"));

            migrationBuilder.DeleteData(
                table: "WatersTypes",
                keyColumn: "Id",
                keyValue: new Guid("0b4f1f78-e966-4f92-aa71-dac67c3a6020"));

            migrationBuilder.DeleteData(
                table: "WatersTypes",
                keyColumn: "Id",
                keyValue: new Guid("81823956-e0de-4abf-b292-94d154efe6ad"));

            migrationBuilder.DeleteData(
                table: "WatersTypes",
                keyColumn: "Id",
                keyValue: new Guid("fcb40261-58d2-4c72-bda2-b37e937935e3"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "ApiUsers");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "ApiUsers");

            migrationBuilder.InsertData(
                table: "Cantons",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("17f586d2-4461-444e-bc19-3da43d1d9567"), "BS", "Basel-Stadt" },
                    { new Guid("182380c0-f138-42c8-bb0a-00b6219c178b"), "NW", "Nidwalden" },
                    { new Guid("1df1c365-55f4-49cb-8a7b-702cd6c5896f"), "AI", "Appenzell Innerrhoden" },
                    { new Guid("24ae391c-7381-4c24-a6c4-d1d3bed8ced8"), "TI", "Tessin" },
                    { new Guid("2bd5c275-5ca0-428a-9f33-9102110022ac"), "ZG", "Zug" },
                    { new Guid("37e55fb8-a163-414b-a919-c5aabb13eef9"), "GL", "Glarus" },
                    { new Guid("47b82674-9612-41f5-9b77-007167002e04"), "JU", "Jura" },
                    { new Guid("5031046d-7c2c-4643-afa0-96b046613dcf"), "UR", "Uri" },
                    { new Guid("5716545e-d27e-4745-8dcb-ee023176f983"), "AG", "Aargau" },
                    { new Guid("671fcec2-d9f0-4c81-a8ec-e646cbcd865b"), "TG", "Thurgau" },
                    { new Guid("6abaca87-a74f-4447-bf70-90065e62c112"), "VS", "Wallis" },
                    { new Guid("711bde57-0040-49ea-90cf-140db48ec31b"), "OW", "Obwalden" },
                    { new Guid("760d081f-cf05-4a67-8f7d-ab095f373a7e"), "GE", "Genf" },
                    { new Guid("76107c5a-364a-4ee5-b7ce-24a980ade31a"), "SH", "Schaffhausen" },
                    { new Guid("76291f40-b773-4324-9351-96a7c947ef80"), "SO", "Solothurn" },
                    { new Guid("80a07fc2-69de-4abb-9092-e1920347c8e0"), "AR", "Appenzell Ausserrhoden" },
                    { new Guid("894210d0-ae51-431b-9d39-8ae09c3447a7"), "BL", "Basel-Landschaft" },
                    { new Guid("95fd99ce-acea-4680-bd0a-3ebc113357ac"), "GR", "Graubünden" },
                    { new Guid("aceabbd5-c662-4b62-be44-7d66d2f082b0"), "BE", "Bern" },
                    { new Guid("b9a4df45-6fcc-448b-b6ff-b7d1eadc9fca"), "SZ", "Schwyz" },
                    { new Guid("c3cb4420-81fe-4d19-9e20-9114abf3dd83"), "SG", "St. Gallen" },
                    { new Guid("cd5cc8c7-7846-4fb9-b4a4-1fa18e0428d4"), "NE", "Neuenburg" },
                    { new Guid("cdeb7950-ffcf-485f-8ea1-e44f18909bc8"), "LU", "Luzern" },
                    { new Guid("dceaf89e-80a1-4984-938c-2f4193c90008"), "FR", "Freiburg" },
                    { new Guid("e629f4e2-f0ab-457f-9433-2d4856b2babc"), "ZH", "Zürich" },
                    { new Guid("f711588e-d1b6-4eee-aabe-2822adfc023a"), "VD", "Waadt" }
                });

            migrationBuilder.InsertData(
                table: "WatersTypes",
                columns: new[] { "Id", "Identifier", "Name" },
                values: new object[,]
                {
                    { new Guid("08108061-28dc-474f-8b85-b0b3ed787c22"), "STREAM", "Bach" },
                    { new Guid("af331903-b86f-4836-8a74-40755fd7daaa"), "RIVER", "Fluss" },
                    { new Guid("e8e0baaa-27b4-4391-8b43-ea0ef0a472f7"), "LAKE", "See" }
                });
        }
    }
}
