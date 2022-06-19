using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyWayApp23.Migrations
{
    /// <inheritdoc />
    public partial class Historico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assistencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Aeroporto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Msg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Voo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrigDest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CkIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transferencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraEmbarque = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SaidaStaging = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimaApresentacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoAssistencias",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Msg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aeroporto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notif = table.Column<long>(type: "bigint", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contacto = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Calcos = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duracao = table.Column<long>(type: "bigint", nullable: false),
                    Voo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrigDest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CkIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transferencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Equipamentos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Justificacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoAssistencias", x => x.Id);
                });

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
                values: new object[] { "2f546024-e6d1-4302-8697-ba176c5687f5", "AQAAAAIAAYagAAAAEN8fhVHG0B5EDnheV/iAhAxHI+vQpXnEi09MYUgdQAuekw02NIi3NjIaWW6RhYljBg==" });

            migrationBuilder.InsertData(
                table: "Stands",
                columns: new[] { "Id", "Aeroporto", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy", "Numero", "Tipo" },
                values: new object[,]
                {
                    { new Guid("05296417-dda6-4a8d-bfa9-f3b8e6f227df"), "Lis", null, "", null, "", "144", "JETBRIDGE" },
                    { new Guid("07047f82-f78e-4f2b-9bef-727fb0b8562b"), "Lis", null, "", null, "", "804", "REMOTE" },
                    { new Guid("08631682-9535-424c-bd29-9bf28b689694"), "Lis", null, "", null, "", "423", "REMOTE" },
                    { new Guid("0b8f5d48-a641-4aff-927f-80842936a31f"), "Lis", null, "", null, "", "405", "REMOTE" },
                    { new Guid("0efa2638-e7ed-4af9-bbb6-e11dba1f69b3"), "Lis", null, "", null, "", "421", "REMOTE" },
                    { new Guid("1164cf25-b7dc-4a9a-baae-850f0292076d"), "Lis", null, "", null, "", "118", "JETBRIDGE" },
                    { new Guid("13da7ddc-9211-4533-828d-d5ad1910bc00"), "Lis", null, "", null, "", "414", "REMOTE" },
                    { new Guid("145f811c-63e1-492c-a0c5-69608bec0595"), "Lis", null, "", null, "", "503", "REMOTE" },
                    { new Guid("15608536-b40a-487f-aa39-1d8827d38c66"), "Lis", null, "", null, "", "601", "REMOTE" },
                    { new Guid("171ae922-3bdb-49f0-a0aa-c3627022b3f4"), "Lis", null, "", null, "", "605", "REMOTE" },
                    { new Guid("182cb744-0177-45d7-abdc-294d09eba5bb"), "Lis", null, "", null, "", "501", "REMOTE" },
                    { new Guid("19ca39a2-936b-4ac8-a2d7-ea01dedcf929"), "Lis", null, "", null, "", "224", "REMOTE" },
                    { new Guid("1d234287-6edb-4b71-8c55-2182248768e0"), "Lis", null, "", null, "", "603", "REMOTE" },
                    { new Guid("1e7435dc-19ff-4008-9137-3e174806ea06"), "Lis", null, "", null, "", "600", "REMOTE" },
                    { new Guid("1ec787fc-1cfc-40f1-a755-f4278bbed9ec"), "Lis", null, "", null, "", "505", "REMOTE" },
                    { new Guid("2818b85c-16fa-43aa-9f28-1b7359e38f7d"), "Lis", null, "", null, "", "221", "REMOTE" },
                    { new Guid("2db61a58-a253-4882-9e2c-8bc73bf3a24f"), "Lis", null, "", null, "", "422", "REMOTE" },
                    { new Guid("3d7eb0fd-cc69-4d01-919f-b20b0321088f"), "Lis", null, "", null, "", "145", "JETBRIDGE" },
                    { new Guid("40fef9be-caa7-443c-8fb8-c2d574af9509"), "Lis", null, "", null, "", "403", "REMOTE" },
                    { new Guid("423d7c64-4437-4da5-8dbe-447755411bb2"), "Lis", null, "", null, "", "301", "REMOTE" },
                    { new Guid("43e0bcbb-36b2-4ae1-887a-170238d4d69c"), "Lis", null, "", null, "", "200", "REMOTE" },
                    { new Guid("4626709b-ec1d-4269-93e7-035281dc3ff5"), "Lis", null, "", null, "", "426", "REMOTE" },
                    { new Guid("475fa77c-031d-4a47-baf3-b9fab14e9844"), "Lis", null, "", null, "", "806", "REMOTE" },
                    { new Guid("49010979-47f3-443b-9986-0f79d514e640"), "Lis", null, "", null, "", "608", "REMOTE" },
                    { new Guid("4c038a88-323c-4579-8727-ac64d09fe98d"), "Lis", null, "", null, "", "122", "JETBRIDGE" },
                    { new Guid("4d066c34-df7b-4bc3-a3be-e23282c90406"), "Lis", null, "", null, "", "705", "REMOTE" },
                    { new Guid("50c7a6a1-b791-443d-9579-ea7e42c30d0d"), "Lis", null, "", null, "", "203", "REMOTE" },
                    { new Guid("516e14c7-6733-4228-8287-5cf93272364b"), "Lis", null, "", null, "", "223", "REMOTE" },
                    { new Guid("589f2cd7-c73e-400a-80e8-a0760bfbf204"), "Lis", null, "", null, "", "607", "REMOTE" },
                    { new Guid("5c76aeee-1a9b-45f3-b240-c07f30cfd183"), "Lis", null, "", null, "", "205", "REMOTE" },
                    { new Guid("5fbd73ea-6523-4540-8918-49c00e527ccb"), "Lis", null, "", null, "", "108", "JETBRIDGE" },
                    { new Guid("6085252c-2f91-4dfd-a15b-dbd1c90fcdcc"), "Lis", null, "", null, "", "606", "REMOTE" },
                    { new Guid("65e1ed7f-4ee6-42fa-a14f-562d6b4e07df"), "Lis", null, "", null, "", "123", "JETBRIDGE" },
                    { new Guid("68e65516-bc78-45cc-946a-c57711cc7481"), "Lis", null, "", null, "", "206", "REMOTE" },
                    { new Guid("6b0642be-3580-47f2-a80a-20479de9cea2"), "Lis", null, "", null, "", "121", "JETBRIDGE" },
                    { new Guid("740a269f-6a6d-4269-8162-5351c43385d8"), "Lis", null, "", null, "", "609", "REMOTE" },
                    { new Guid("7431e3af-783c-4dc4-93cb-8c363eed4f48"), "Lis", null, "", null, "", "302", "REMOTE" },
                    { new Guid("77ac0155-cc40-47f0-b011-3df3673e1d53"), "Lis", null, "", null, "", "604", "REMOTE" },
                    { new Guid("79546923-49ed-4e06-9e52-c8ef10515d72"), "Lis", null, "", null, "", "201", "REMOTE" },
                    { new Guid("7b666508-4fb0-4c72-b708-82261eb83dca"), "Lis", null, "", null, "", "126", "JETBRIDGE" },
                    { new Guid("7bff4137-a4ed-4c80-ace6-c040bf9c8267"), "Lis", null, "", null, "", "425", "REMOTE" },
                    { new Guid("7d4e68d9-b9e6-4bc2-8264-159da450341c"), "Lis", null, "", null, "", "119", "JETBRIDGE" },
                    { new Guid("7e524414-8fe6-49e9-a1ec-9d9c21762c26"), "Lis", null, "", null, "", "105", "REMOTE" },
                    { new Guid("838c0563-321a-474c-860d-fcee68c5afa5"), "Lis", null, "", null, "", "208", "REMOTE" },
                    { new Guid("8538c153-2143-46ec-9736-3fcb7db359af"), "Lis", null, "", null, "", "106", "REMOTE" },
                    { new Guid("85c5ad4a-202a-4f34-9bd2-aeffc9e79bb4"), "Lis", null, "", null, "", "801", "REMOTE" },
                    { new Guid("88e55366-020c-4f2f-9afa-daa9a4a6428a"), "Lis", null, "", null, "", "142", "JETBRIDGE" },
                    { new Guid("8cabe186-7a7a-470d-940b-c4a52a715698"), "Lis", null, "", null, "", "703", "REMOTE" },
                    { new Guid("9210915d-62f4-4b68-a899-3c44f84f1539"), "Lis", null, "", null, "", "117", "JETBRIDGE" },
                    { new Guid("9f14c722-44f0-4c74-a47b-434960a73040"), "Lis", null, "", null, "", "802", "REMOTE" },
                    { new Guid("a25c84ce-058f-48ba-865e-513a22362665"), "Lis", null, "", null, "", "805", "REMOTE" },
                    { new Guid("a412eda4-87a0-4f27-8025-71a9fa705fd6"), "Lis", null, "", null, "", "701", "REMOTE" },
                    { new Guid("ac94eb2c-ad87-466f-ab06-f5401dbd5cb3"), "Lis", null, "", null, "", "209", "REMOTE" },
                    { new Guid("ad02ec72-4816-4aa9-96f5-a805b3930e02"), "Lis", null, "", null, "", "127", "JETBRIDGE" },
                    { new Guid("b03f120b-625b-4862-9f4f-a4712dc26d4e"), "Lis", null, "", null, "", "146", "JETBRIDGE" },
                    { new Guid("b2b0d27d-772b-4f43-9c9e-46bde56f3803"), "Lis", null, "", null, "", "207", "REMOTE" },
                    { new Guid("b4638b90-2911-41e0-9488-0290c271ba2c"), "Lis", null, "", null, "", "140", "JETBRIDGE" },
                    { new Guid("b69f91b0-bb06-40c2-83fe-b6bd6c022954"), "Lis", null, "", null, "", "704", "REMOTE" },
                    { new Guid("bab04a35-0b04-4a1b-b954-3f579be3c028"), "Lis", null, "", null, "", "120", "JETBRIDGE" },
                    { new Guid("bc0a3c2a-fc59-4a47-8e24-c025b2fd1d60"), "Lis", null, "", null, "", "202", "REMOTE" },
                    { new Guid("bd20a470-1361-44cb-94e2-aafacc2ddc1a"), "Lis", null, "", null, "", "115", "JETBRIDGE" },
                    { new Guid("be098440-c479-4dca-86ee-67010d873a67"), "Lis", null, "", null, "", "225", "REMOTE" },
                    { new Guid("c2273d52-fc7d-4cad-8cd7-8c5a93526f56"), "Lis", null, "", null, "", "204", "REMOTE" },
                    { new Guid("c89fc436-dcd5-452d-9cb3-b4f1f0d3413c"), "Lis", null, "", null, "", "506", "REMOTE" },
                    { new Guid("c9d1707a-c9a1-4b50-b7ad-2ac1c7212dc3"), "Lis", null, "", null, "", "222", "REMOTE" },
                    { new Guid("cd74fb3a-e79e-4f38-a197-d91f011d1ed4"), "Lis", null, "", null, "", "502", "REMOTE" },
                    { new Guid("cdc576d1-3b95-4887-a348-11dd5b9a95fd"), "Lis", null, "", null, "", "424", "REMOTE" },
                    { new Guid("d64c9843-8980-4df8-94bd-b1f658019573"), "Lis", null, "", null, "", "141", "JETBRIDGE" },
                    { new Guid("d6a14acf-13db-4863-8dff-7e17e42729f5"), "Lis", null, "", null, "", "413", "REMOTE" },
                    { new Guid("d724cb8c-1a6e-4037-9a51-ecce8e2c7ffe"), "Lis", null, "", null, "", "500", "REMOTE" },
                    { new Guid("d8daa433-31e3-4130-869f-45b21e495138"), "Lis", null, "", null, "", "504", "REMOTE" },
                    { new Guid("db44f244-757f-4a26-a057-f4e31c2c16ad"), "Lis", null, "", null, "", "143", "JETBRIDGE" },
                    { new Guid("dbce99a8-8975-4d9d-86c0-3bfe9a419b48"), "Lis", null, "", null, "", "107", "JETBRIDGE" },
                    { new Guid("e1814a73-ddfd-4448-b5da-75378a0124d9"), "Lis", null, "", null, "", "125", "JETBRIDGE" },
                    { new Guid("e21a33e4-479c-4962-95e2-8d11b5113d09"), "Lis", null, "", null, "", "416", "REMOTE" },
                    { new Guid("e2bc8952-830e-4698-8173-7b9d06caa91f"), "Lis", null, "", null, "", "411", "REMOTE" },
                    { new Guid("e41fadd5-b3a9-44ee-b61d-8cbe5b22e7a9"), "Lis", null, "", null, "", "116", "JETBRIDGE" },
                    { new Guid("e56a42ac-04cb-4571-a1fc-5dd03b07fdb7"), "Lis", null, "", null, "", "415", "REMOTE" },
                    { new Guid("e581751a-e004-4fbd-a63e-b30aae9b5732"), "Lis", null, "", null, "", "803", "REMOTE" },
                    { new Guid("ea462a3a-daec-471e-a859-66a332d4eb49"), "Lis", null, "", null, "", "147", "JETBRIDGE" },
                    { new Guid("eccabd8a-7d52-43cc-a465-efb22dc9bcd9"), "Lis", null, "", null, "", "104", "REMOTE" },
                    { new Guid("ed72fb17-c36a-469a-8bb5-76150e5ced72"), "Lis", null, "", null, "", "412", "REMOTE" },
                    { new Guid("ef3489eb-6f0b-4fa3-b0e0-92225290d9aa"), "Lis", null, "", null, "", "702", "REMOTE" },
                    { new Guid("ef4e202f-85f9-47a8-a130-a21bf2f0b90c"), "Lis", null, "", null, "", "114", "JETBRIDGE" },
                    { new Guid("f23e868d-0234-41b3-bd9f-664a17133e63"), "Lis", null, "", null, "", "402", "REMOTE" },
                    { new Guid("f3f3d435-dcee-4b5e-a75a-e1c1738b867e"), "Lis", null, "", null, "", "404", "REMOTE" },
                    { new Guid("f5031bcc-a090-4adc-9804-52521934be50"), "Lis", null, "", null, "", "401", "REMOTE" },
                    { new Guid("f8a36fe5-fcb0-4975-ae62-c02314116b55"), "Lis", null, "", null, "", "706", "REMOTE" },
                    { new Guid("ff8cf653-8767-4cd3-a710-26345f360a44"), "Lis", null, "", null, "", "124", "JETBRIDGE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assistencias");

            migrationBuilder.DropTable(
                name: "HistoricoAssistencias");

            migrationBuilder.DropTable(
                name: "Stands");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "206a401d-ca2e-4aba-a7bb-2a91a5011b5b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "190e635d-5998-48dc-96f4-e055e1afc3a3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "f5f98b93-09e2-42f9-a3d2-7ee2fd383802");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fa43032a-8798-4174-9a47-723f69895d92", "AQAAAAEAACcQAAAAEKK9Xf4Bc0WQH/RiHSsZdJNzE9y9LbgRtcrfa112ibuYqikJW2mx3KyNzlqmbMHyBg==" });
        }
    }
}
