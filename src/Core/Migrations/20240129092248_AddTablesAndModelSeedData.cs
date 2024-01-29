using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesAndModelSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Background = table.Column<bool>(type: "bit", nullable: true),
                    Split = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllDay = table.Column<bool>(type: "bit", nullable: true),
                    Deletable = table.Column<bool>(type: "bit", nullable: true),
                    Resizable = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ferie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    Dettagli = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ferie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NottiFuori",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoViaggio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Commessa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dettagli = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NottiFuori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permessi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OraInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OraFine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    Dettagli = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permessi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rendicontazioni",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OreTotali = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OraInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OraFine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Commessa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dettagli = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rendicontazioni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rimborsi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Importo = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Commessa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartaAziendale = table.Column<bool>(type: "bit", nullable: false),
                    Dettagli = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rimborsi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trasferte",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Chilometri = table.Column<int>(type: "int", nullable: false),
                    DataInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Commessa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutoAziendale = table.Column<bool>(type: "bit", nullable: false),
                    Dettagli = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trasferte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Eventi",
                columns: new[] { "Id", "AllDay", "Background", "Class", "Content", "Deletable", "End", "Resizable", "Split", "Start", "Title" },
                values: new object[,]
                {
                    { new Guid("5756b08c-2a5c-4cb5-b3e6-43b0fc2efb98"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 29, 8, 30, 0, 0, DateTimeKind.Unspecified), "Prova rendicontazione" },
                    { new Guid("6467ba2c-4de7-4533-9207-0047150128a0"), false, false, "trasferta", null, false, new DateTime(2024, 1, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "Prova trasferta" },
                    { new Guid("8ebded23-b951-440c-a7bb-0fae54eaa740"), true, true, "libero", null, false, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 2, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Prova feria" },
                    { new Guid("9bc6f3d5-9fa2-4e9b-9922-09540e41dda8"), false, false, "straordinario", null, false, new DateTime(2024, 1, 29, 22, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 29, 19, 0, 0, 0, DateTimeKind.Unspecified), "Prova straordinario" },
                    { new Guid("edf34801-4ae1-48ca-9d01-651d15d63f40"), false, false, "permesso", null, false, new DateTime(2024, 1, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), "Prova permesso" }
                });

            migrationBuilder.InsertData(
                table: "Ferie",
                columns: new[] { "Id", "DataFine", "DataInizio", "Dettagli", "Durata" },
                values: new object[] { new Guid("dd415088-2d31-41c9-95d4-467eb7b168ed"), new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di Ferie", 60 });

            migrationBuilder.InsertData(
                table: "Permessi",
                columns: new[] { "Id", "Data", "Dettagli", "Durata", "OraFine", "OraInizio" },
                values: new object[] { new Guid("4b422ac4-1b1e-4a9c-bb02-9e73fd70c3c3"), new DateTime(2024, 1, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di permesso", 180, new DateTime(2024, 1, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Rendicontazioni",
                columns: new[] { "Id", "Commessa", "Data", "Dettagli", "OraFine", "OraInizio", "OreTotali" },
                values: new object[] { new Guid("a5e23dcc-d26a-4c66-a5bc-a7529b89db14"), "Commessa di rendicontazione", new DateTime(2024, 1, 29, 8, 30, 0, 0, DateTimeKind.Unspecified), "Dettagli di Rendicontazioni", new DateTime(2024, 1, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 29, 8, 30, 0, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.InsertData(
                table: "Trasferte",
                columns: new[] { "Id", "AutoAziendale", "Chilometri", "Commessa", "DataFine", "DataInizio", "Dettagli" },
                values: new object[] { new Guid("2b7f6f04-88c3-4abb-9b81-390a75e6973d"), false, 200, "Commessa di Trasferte", new DateTime(2024, 1, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di Trasferte" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "NickName", "Password" },
                values: new object[,]
                {
                    { new Guid("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), "email1@test.it", "Nome1", "Cognome1", "Nickname1", "M0Cuk9OsrcS/rTLGf5SY6DUPqU2rGc1wwV2IL88GVGo=" },
                    { new Guid("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), "email2@test.it", "Nome2", "Cognome2", "Nickname2", "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=" },
                    { new Guid("bfdef48b-c7ea-4227-8333-c635af267354"), "email3@test.it", "Nome3", "Cognome3", "Nickname3", "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventi");

            migrationBuilder.DropTable(
                name: "Ferie");

            migrationBuilder.DropTable(
                name: "NottiFuori");

            migrationBuilder.DropTable(
                name: "Permessi");

            migrationBuilder.DropTable(
                name: "Rendicontazioni");

            migrationBuilder.DropTable(
                name: "Rimborsi");

            migrationBuilder.DropTable(
                name: "Trasferte");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
