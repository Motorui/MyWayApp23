using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyWayApp23.Migrations
{
    /// <inheritdoc />
    public partial class Stands : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrigDest",
                table: "HistoricoAssistencias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AC",
                table: "HistoricoAssistencias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Stands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Aeroporto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stands", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "70dcae22-9ccc-45bf-9807-86e3fbe1db22", "AQAAAAIAAYagAAAAEAmJCuMtFlgkYAZI8fEKCvrHJVH/Vim38W5pqN8DxdHUIs0uM1IOjyH9Qa6UGkQp6A==" });

            migrationBuilder.InsertData(
                table: "Stands",
                columns: new[] { "Id", "Aeroporto", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy", "Numero", "Tipo" },
                values: new object[,]
                {
                    { new Guid("0400f7bc-7985-4aab-88b0-4bc621e25eed"), "Lis", null, "", null, "", "119", "JETBRIDGE" },
                    { new Guid("044cda4e-7b5e-4942-8b3d-377c54660fa9"), "Lis", null, "", null, "", "600", "REMOTE" },
                    { new Guid("0c9fd0d4-f14b-437e-bfde-88085d3c7b14"), "Lis", null, "", null, "", "702", "REMOTE" },
                    { new Guid("0efe2360-57a6-48e9-8ff5-9d4a81165228"), "Lis", null, "", null, "", "223", "REMOTE" },
                    { new Guid("10727444-4e84-41f8-802c-de15610d7d7a"), "Lis", null, "", null, "", "207", "REMOTE" },
                    { new Guid("10c712a7-353a-4e6e-9344-e58c86e75a9a"), "Lis", null, "", null, "", "501", "REMOTE" },
                    { new Guid("14953810-d01a-4f57-94ab-360739d8eb46"), "Lis", null, "", null, "", "500", "REMOTE" },
                    { new Guid("1cb5467f-4764-42d9-bed5-b7adfd939192"), "Lis", null, "", null, "", "121", "JETBRIDGE" },
                    { new Guid("21794338-e7b4-47c1-94d6-23ff68f01645"), "Lis", null, "", null, "", "125", "JETBRIDGE" },
                    { new Guid("25add1af-8bb7-4e1d-aabc-3544f4539447"), "Lis", null, "", null, "", "401", "REMOTE" },
                    { new Guid("26016952-c71b-4c37-9302-19e058cf47a7"), "Lis", null, "", null, "", "225", "REMOTE" },
                    { new Guid("26fed09a-5819-4374-bbea-ead10599bb2b"), "Lis", null, "", null, "", "421", "REMOTE" },
                    { new Guid("2941219e-7c48-4345-b8a0-92d6e601ef1c"), "Lis", null, "", null, "", "208", "REMOTE" },
                    { new Guid("2b2dc471-24bf-4010-ba3a-95a73b7fd942"), "Lis", null, "", null, "", "805", "REMOTE" },
                    { new Guid("2e6ea7f7-3c3d-4df4-b0f6-a06e13fcdff9"), "Lis", null, "", null, "", "402", "REMOTE" },
                    { new Guid("34c84b25-e161-424d-b2db-a8999f62517d"), "Lis", null, "", null, "", "414", "REMOTE" },
                    { new Guid("34f9199b-fb0c-4c19-93e8-c74d86834599"), "Lis", null, "", null, "", "413", "REMOTE" },
                    { new Guid("3610367e-4eb8-425d-addb-82827d6e6bd6"), "Lis", null, "", null, "", "404", "REMOTE" },
                    { new Guid("36fcf91e-b34e-44f4-aef0-69ede7e6c52c"), "Lis", null, "", null, "", "425", "REMOTE" },
                    { new Guid("3effb17f-d0b7-4669-8174-73d15bc08fe5"), "Lis", null, "", null, "", "147", "JETBRIDGE" },
                    { new Guid("40253c47-fc0b-4d27-8288-770c0be09335"), "Lis", null, "", null, "", "122", "JETBRIDGE" },
                    { new Guid("40ac4bbf-7bfc-4a83-9a1b-b04f72958e1c"), "Lis", null, "", null, "", "202", "REMOTE" },
                    { new Guid("42bf92b1-15ba-427e-aeea-73056464bf95"), "Lis", null, "", null, "", "204", "REMOTE" },
                    { new Guid("42ef9695-5e17-45bb-ae61-b3c20f942049"), "Lis", null, "", null, "", "146", "JETBRIDGE" },
                    { new Guid("430e3c02-9af1-4621-868b-7b6d3204ff3f"), "Lis", null, "", null, "", "126", "JETBRIDGE" },
                    { new Guid("487262ca-262d-4319-ae1e-d185a8bddb5d"), "Lis", null, "", null, "", "608", "REMOTE" },
                    { new Guid("4aa0b93d-e191-4e18-8825-9b278d4517b9"), "Lis", null, "", null, "", "114", "JETBRIDGE" },
                    { new Guid("4e195678-a901-4a1e-b9ca-e6f5cfd94f78"), "Lis", null, "", null, "", "118", "JETBRIDGE" },
                    { new Guid("5291179c-9702-44d5-b298-2f3aa62bd782"), "Lis", null, "", null, "", "601", "REMOTE" },
                    { new Guid("52b4f52f-cffb-4704-8ebd-b41ef495debd"), "Lis", null, "", null, "", "205", "REMOTE" },
                    { new Guid("52cfb923-768e-4603-b295-c852c16ca9ca"), "Lis", null, "", null, "", "422", "REMOTE" },
                    { new Guid("53816e76-e7f4-4a76-b2fa-bc75f191ef24"), "Lis", null, "", null, "", "609", "REMOTE" },
                    { new Guid("5716d8e6-045d-4f4a-acf3-553baa9e53b4"), "Lis", null, "", null, "", "144", "JETBRIDGE" },
                    { new Guid("58b24048-bf94-43de-a7fb-2a67220442ac"), "Lis", null, "", null, "", "104", "REMOTE" },
                    { new Guid("5a671c0e-bf16-49cb-b344-6d193c5dae8c"), "Lis", null, "", null, "", "415", "REMOTE" },
                    { new Guid("61bfee61-87df-4ebd-b3c2-e0d4792725a4"), "Lis", null, "", null, "", "224", "REMOTE" },
                    { new Guid("61f02c03-03ec-4f0b-897b-dea84730bcea"), "Lis", null, "", null, "", "603", "REMOTE" },
                    { new Guid("6a339a67-cb96-4ff7-8364-da0fdc803aff"), "Lis", null, "", null, "", "424", "REMOTE" }
                });

            migrationBuilder.InsertData(
                table: "Stands",
                columns: new[] { "Id", "Aeroporto", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy", "Numero", "Tipo" },
                values: new object[,]
                {
                    { new Guid("6a9a5550-5ea0-4053-80d8-5d4d33b4f033"), "Lis", null, "", null, "", "145", "JETBRIDGE" },
                    { new Guid("6d849c3d-954b-4e69-9a59-288570a2f623"), "Lis", null, "", null, "", "209", "REMOTE" },
                    { new Guid("6fa22363-326d-4b56-941e-e3ed903a7a2c"), "Lis", null, "", null, "", "416", "REMOTE" },
                    { new Guid("7065bf9b-96ad-478c-86e1-40ff659a871c"), "Lis", null, "", null, "", "108", "JETBRIDGE" },
                    { new Guid("70c8d872-bf55-4b8d-b778-ab97b3d8067a"), "Lis", null, "", null, "", "405", "REMOTE" },
                    { new Guid("75697e36-cfb9-44f5-bff4-bcfc485d50ed"), "Lis", null, "", null, "", "123", "JETBRIDGE" },
                    { new Guid("76766ecd-58c3-44bd-a3a5-b6b2596aa20d"), "Lis", null, "", null, "", "203", "REMOTE" },
                    { new Guid("7f76fe62-b8a0-4007-8106-6ea2e6e9228a"), "Lis", null, "", null, "", "706", "REMOTE" },
                    { new Guid("810bd0a4-c576-4273-bc5d-aae3841db17a"), "Lis", null, "", null, "", "140", "JETBRIDGE" },
                    { new Guid("8b0fffd4-f8f6-47ac-8951-ed2ab29e50e0"), "Lis", null, "", null, "", "803", "REMOTE" },
                    { new Guid("914b142d-9e56-4b37-bbc9-2912f6e80557"), "Lis", null, "", null, "", "705", "REMOTE" },
                    { new Guid("916fa702-1739-4016-a824-bef917797039"), "Lis", null, "", null, "", "221", "REMOTE" },
                    { new Guid("9310bcfb-1363-4947-b851-ff8dfec45672"), "Lis", null, "", null, "", "426", "REMOTE" },
                    { new Guid("94ab0fcd-ddfd-44b5-9792-1b238a416038"), "Lis", null, "", null, "", "504", "REMOTE" },
                    { new Guid("96ff0f4b-2e71-4fe2-8bce-e4ab7a492a56"), "Lis", null, "", null, "", "120", "JETBRIDGE" },
                    { new Guid("985d8bf8-2fef-41c5-ad0b-4b2460bca857"), "Lis", null, "", null, "", "703", "REMOTE" },
                    { new Guid("ab2c3a88-ad21-4fff-8631-45e8dadbf334"), "Lis", null, "", null, "", "411", "REMOTE" },
                    { new Guid("ade4613a-b97c-49f0-b025-1596c4c053de"), "Lis", null, "", null, "", "142", "JETBRIDGE" },
                    { new Guid("b216ba52-cf2e-4e87-8561-c392d71ca473"), "Lis", null, "", null, "", "141", "JETBRIDGE" },
                    { new Guid("b29a4180-1f52-4f10-a51a-b1b20029a89c"), "Lis", null, "", null, "", "200", "REMOTE" },
                    { new Guid("b4308787-091d-4c1c-8f0b-08b80cea5795"), "Lis", null, "", null, "", "806", "REMOTE" },
                    { new Guid("b62a5989-fee9-492c-97ec-529a50147d84"), "Lis", null, "", null, "", "502", "REMOTE" },
                    { new Guid("b641f46b-8237-4499-a9b3-d8fdfd19ec34"), "Lis", null, "", null, "", "604", "REMOTE" },
                    { new Guid("b73073d5-e13e-4562-ad9f-19c4d412995c"), "Lis", null, "", null, "", "124", "JETBRIDGE" },
                    { new Guid("b83d4117-7c1a-4aa8-af33-df1214b3360d"), "Lis", null, "", null, "", "503", "REMOTE" },
                    { new Guid("bdec30c2-46f0-4595-8b26-ebaef958ce4b"), "Lis", null, "", null, "", "143", "JETBRIDGE" },
                    { new Guid("bee45983-ee7a-4c9f-a8aa-8d082977be30"), "Lis", null, "", null, "", "117", "JETBRIDGE" },
                    { new Guid("c2413e9c-e086-497f-8302-e30db4e75495"), "Lis", null, "", null, "", "804", "REMOTE" },
                    { new Guid("c44bb4fe-af72-445f-a187-b631a3a3d0af"), "Lis", null, "", null, "", "403", "REMOTE" },
                    { new Guid("c4f32ff0-61f3-4dc8-a2b1-bd61f9b3a52c"), "Lis", null, "", null, "", "505", "REMOTE" },
                    { new Guid("c9a55db0-314b-40fc-9cdc-b98bfd4bcbd7"), "Lis", null, "", null, "", "206", "REMOTE" },
                    { new Guid("cb3fca0b-ff7d-4fde-8150-63328fab5519"), "Lis", null, "", null, "", "105", "REMOTE" },
                    { new Guid("cd739270-72fc-424b-ae3d-f1e1cdb483e9"), "Lis", null, "", null, "", "506", "REMOTE" },
                    { new Guid("d22b39a0-c4f8-45cd-8e71-9a8fc546eca3"), "Lis", null, "", null, "", "605", "REMOTE" },
                    { new Guid("d3d483c2-7df1-49a3-8160-2345465545f8"), "Lis", null, "", null, "", "106", "REMOTE" },
                    { new Guid("d6c71305-a0c1-456f-9a0e-fb9f379f538c"), "Lis", null, "", null, "", "423", "REMOTE" },
                    { new Guid("dca4b848-4006-4aa0-bcbc-957e55fcadfc"), "Lis", null, "", null, "", "704", "REMOTE" },
                    { new Guid("dfe6ca26-4258-4747-bced-20000e5c9f14"), "Lis", null, "", null, "", "107", "JETBRIDGE" },
                    { new Guid("e1b50c3c-6b97-48ab-8abe-67bbe9d249ba"), "Lis", null, "", null, "", "127", "JETBRIDGE" },
                    { new Guid("e21951d0-f38d-46d4-b604-924757a15a54"), "Lis", null, "", null, "", "607", "REMOTE" },
                    { new Guid("e34a48b8-724b-490e-9079-62b478f6cfd5"), "Lis", null, "", null, "", "801", "REMOTE" },
                    { new Guid("e58a8aa0-281d-483d-8141-b35787ee2160"), "Lis", null, "", null, "", "201", "REMOTE" }
                });

            migrationBuilder.InsertData(
                table: "Stands",
                columns: new[] { "Id", "Aeroporto", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy", "Numero", "Tipo" },
                values: new object[,]
                {
                    { new Guid("e6ba1657-e1e8-443f-9384-2a7e58fbc2a9"), "Lis", null, "", null, "", "301", "REMOTE" },
                    { new Guid("e9503318-7b73-403f-8980-9590e0aac951"), "Lis", null, "", null, "", "701", "REMOTE" },
                    { new Guid("ed7bb2b6-79ee-4d90-8f31-c9119e5d4ebb"), "Lis", null, "", null, "", "115", "JETBRIDGE" },
                    { new Guid("f6a172d6-1aa6-4886-b26e-27da02607e2a"), "Lis", null, "", null, "", "412", "REMOTE" },
                    { new Guid("f7516fe5-b54f-4e35-8cad-69b5b6c5ecb8"), "Lis", null, "", null, "", "222", "REMOTE" },
                    { new Guid("f8813662-e93a-49af-8558-8481ac4a2855"), "Lis", null, "", null, "", "116", "JETBRIDGE" },
                    { new Guid("fac6c97a-f20d-40db-b36e-0d2ae4f4d8f8"), "Lis", null, "", null, "", "302", "REMOTE" },
                    { new Guid("fd7c213a-6a83-40ad-bb94-66c98af33368"), "Lis", null, "", null, "", "802", "REMOTE" },
                    { new Guid("ff257c51-39f0-4bee-9885-9788c093dd11"), "Lis", null, "", null, "", "606", "REMOTE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stands");

            migrationBuilder.AlterColumn<string>(
                name: "OrigDest",
                table: "HistoricoAssistencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AC",
                table: "HistoricoAssistencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "22f5c1b9-cf9f-4861-8f61-d58e6225c63a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "bfbded5a-e1fd-4cb7-a120-c0fe5761ae68");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "98dc4e34-3250-46c7-81ad-e57e8e9a4e4c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "03bff215-e4e7-47a0-b872-44daaa6a50bd", "AQAAAAEAACcQAAAAEDBwIfPZ3iId6B98ofl4NGuUcmDEoMpLqzRWWZQL1rYD44BYLtDI5Ru4iQapem13Aw==" });
        }
    }
}
