using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class addCanton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("158b8222-7cb3-4bd8-9c6b-75e57934e471"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("1c00491a-0bd8-4575-b7f6-db5be2b2363b"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("2b2f56b7-830e-4610-a40e-ab2bca53b6a4"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("435b61d7-970a-469c-a0b2-bdda5b4335e6"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("43834363-61bb-40fa-876f-6d16c872792a"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("475f1b7b-e893-4bec-a5a0-6294b479f00b"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("48826f46-db05-415a-b06f-5ddb2cc87a71"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("50fbc51e-382f-4c28-b9ea-a1b0ddee737e"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("55881cb7-f754-4807-b662-fc0da85fca49"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("57a93995-968f-47f7-82d6-d0d9ef8bc750"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("5bcb93b8-d974-4ecf-809d-ce3de790d02e"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("68de6900-2c99-411b-ba70-4dda1d182f79"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("6aaa1a88-50aa-4f03-aa34-3489a08b4481"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("6dd83801-0864-4834-b82e-2c84f54fcc4d"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("744e8c98-b8a4-45b2-a7c6-ab1321a685ac"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("78cf2bfb-8b0e-4509-8209-0296da25ae15"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("88467cf8-fcb6-4746-aa7c-187e0a9208df"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("961159bd-face-4799-ae3b-3522242801b6"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("c5752110-a67c-420a-a080-8b3576859c1e"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("c7f62dc2-e84b-49ed-a2dd-5352eed10dd1"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("ca7bbb9b-25c4-4e77-9036-3c345f7ca94d"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("e500e626-6b3a-4b0c-b83d-ad95fb11ced7"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("e8ffee67-eeb7-43ff-b6f8-35c8b7fc257f"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("e905c60f-ec94-4e9a-974d-eb4c6d4cfa13"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("ea33cf00-f095-486d-b148-f6290cd2127c"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("f1eca8d6-89b4-496e-962c-5ace77763be7"));

            migrationBuilder.DeleteData(
                table: "WatersTypes",
                keyColumn: "Id",
                keyValue: new Guid("1acae8da-a80f-46e5-b9a8-0f1602c00f67"));

            migrationBuilder.DeleteData(
                table: "WatersTypes",
                keyColumn: "Id",
                keyValue: new Guid("1f773a95-caa8-4107-92df-3c05d2392d1e"));

            migrationBuilder.DeleteData(
                table: "WatersTypes",
                keyColumn: "Id",
                keyValue: new Guid("f948015a-29f9-4733-ae2f-56ed8723b878"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("17f586d2-4461-444e-bc19-3da43d1d9567"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("182380c0-f138-42c8-bb0a-00b6219c178b"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("1df1c365-55f4-49cb-8a7b-702cd6c5896f"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("24ae391c-7381-4c24-a6c4-d1d3bed8ced8"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("2bd5c275-5ca0-428a-9f33-9102110022ac"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("37e55fb8-a163-414b-a919-c5aabb13eef9"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("47b82674-9612-41f5-9b77-007167002e04"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("5031046d-7c2c-4643-afa0-96b046613dcf"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("5716545e-d27e-4745-8dcb-ee023176f983"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("671fcec2-d9f0-4c81-a8ec-e646cbcd865b"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("6abaca87-a74f-4447-bf70-90065e62c112"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("711bde57-0040-49ea-90cf-140db48ec31b"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("760d081f-cf05-4a67-8f7d-ab095f373a7e"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("76107c5a-364a-4ee5-b7ce-24a980ade31a"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("76291f40-b773-4324-9351-96a7c947ef80"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("80a07fc2-69de-4abb-9092-e1920347c8e0"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("894210d0-ae51-431b-9d39-8ae09c3447a7"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("95fd99ce-acea-4680-bd0a-3ebc113357ac"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("aceabbd5-c662-4b62-be44-7d66d2f082b0"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("b9a4df45-6fcc-448b-b6ff-b7d1eadc9fca"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("c3cb4420-81fe-4d19-9e20-9114abf3dd83"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("cd5cc8c7-7846-4fb9-b4a4-1fa18e0428d4"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("cdeb7950-ffcf-485f-8ea1-e44f18909bc8"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("dceaf89e-80a1-4984-938c-2f4193c90008"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("e629f4e2-f0ab-457f-9433-2d4856b2babc"));

            migrationBuilder.DeleteData(
                table: "Cantons",
                keyColumn: "Id",
                keyValue: new Guid("f711588e-d1b6-4eee-aabe-2822adfc023a"));

            migrationBuilder.DeleteData(
                table: "WatersTypes",
                keyColumn: "Id",
                keyValue: new Guid("08108061-28dc-474f-8b85-b0b3ed787c22"));

            migrationBuilder.DeleteData(
                table: "WatersTypes",
                keyColumn: "Id",
                keyValue: new Guid("af331903-b86f-4836-8a74-40755fd7daaa"));

            migrationBuilder.DeleteData(
                table: "WatersTypes",
                keyColumn: "Id",
                keyValue: new Guid("e8e0baaa-27b4-4391-8b43-ea0ef0a472f7"));

            migrationBuilder.InsertData(
                table: "Cantons",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("158b8222-7cb3-4bd8-9c6b-75e57934e471"), "BL", "Basel-Landschaft" },
                    { new Guid("1c00491a-0bd8-4575-b7f6-db5be2b2363b"), "NE", "Neuenburg" },
                    { new Guid("2b2f56b7-830e-4610-a40e-ab2bca53b6a4"), "SH", "Schaffhausen" },
                    { new Guid("435b61d7-970a-469c-a0b2-bdda5b4335e6"), "AR", "Appenzell Ausserrhoden" },
                    { new Guid("43834363-61bb-40fa-876f-6d16c872792a"), "ZH", "Zürich" },
                    { new Guid("475f1b7b-e893-4bec-a5a0-6294b479f00b"), "UR", "Uri" },
                    { new Guid("48826f46-db05-415a-b06f-5ddb2cc87a71"), "SZ", "Schwyz" },
                    { new Guid("50fbc51e-382f-4c28-b9ea-a1b0ddee737e"), "SG", "St. Gallen" },
                    { new Guid("55881cb7-f754-4807-b662-fc0da85fca49"), "ZG", "Zug" },
                    { new Guid("57a93995-968f-47f7-82d6-d0d9ef8bc750"), "FR", "Freiburg" },
                    { new Guid("5bcb93b8-d974-4ecf-809d-ce3de790d02e"), "TG", "Thurgau" },
                    { new Guid("68de6900-2c99-411b-ba70-4dda1d182f79"), "LU", "Luzern" },
                    { new Guid("6aaa1a88-50aa-4f03-aa34-3489a08b4481"), "NW", "Nidwalden" },
                    { new Guid("6dd83801-0864-4834-b82e-2c84f54fcc4d"), "GE", "Genf" },
                    { new Guid("744e8c98-b8a4-45b2-a7c6-ab1321a685ac"), "OW", "Obwalden" },
                    { new Guid("78cf2bfb-8b0e-4509-8209-0296da25ae15"), "VD", "Waadt" },
                    { new Guid("88467cf8-fcb6-4746-aa7c-187e0a9208df"), "GR", "Graubünden" },
                    { new Guid("961159bd-face-4799-ae3b-3522242801b6"), "GL", "Glarus" },
                    { new Guid("c5752110-a67c-420a-a080-8b3576859c1e"), "SO", "Solothurn" },
                    { new Guid("c7f62dc2-e84b-49ed-a2dd-5352eed10dd1"), "BS", "Basel-Stadt" },
                    { new Guid("ca7bbb9b-25c4-4e77-9036-3c345f7ca94d"), "AI", "Appenzell Innerrhoden" },
                    { new Guid("e500e626-6b3a-4b0c-b83d-ad95fb11ced7"), "BE", "Bern" },
                    { new Guid("e8ffee67-eeb7-43ff-b6f8-35c8b7fc257f"), "VS", "Wallis" },
                    { new Guid("e905c60f-ec94-4e9a-974d-eb4c6d4cfa13"), "JU", "Jura" },
                    { new Guid("ea33cf00-f095-486d-b148-f6290cd2127c"), "AG", "Aargau" },
                    { new Guid("f1eca8d6-89b4-496e-962c-5ace77763be7"), "TI", "Tessin" }
                });

            migrationBuilder.InsertData(
                table: "WatersTypes",
                columns: new[] { "Id", "Identifier", "Name" },
                values: new object[,]
                {
                    { new Guid("1acae8da-a80f-46e5-b9a8-0f1602c00f67"), "RIVER", "Fluss" },
                    { new Guid("1f773a95-caa8-4107-92df-3c05d2392d1e"), "STREAM", "Bach" },
                    { new Guid("f948015a-29f9-4733-ae2f-56ed8723b878"), "LAKE", "See" }
                });
        }
    }
}
