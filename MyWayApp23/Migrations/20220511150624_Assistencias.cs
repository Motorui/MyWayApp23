using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWayApp23.Migrations
{
    public partial class Assistencias : Migration
    {
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Msg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aeroporto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contacto = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Calcos = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Voo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrigDest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AC = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assistencias");

            migrationBuilder.DropTable(
                name: "HistoricoAssistencias");

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
