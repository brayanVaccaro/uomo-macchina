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
                    OreTotali = table.Column<int>(type: "int", nullable: false),
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
                    Straordinario = table.Column<bool>(type: "bit", nullable: false),
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
                    { new Guid("055263b8-2133-4e5b-b740-eea0e23becff"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("0bd563b3-d951-4437-8e5e-82f8858314a9"), false, false, "permesso", null, false, new DateTime(2024, 2, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 2, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), "Permesso" },
                    { new Guid("0e26aa2f-9162-4947-a7ba-f4ee9b634a24"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("13327f06-fc7a-4b01-b997-73be8d27b751"), false, false, "trasferta", null, false, new DateTime(2024, 1, 16, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 16, 6, 0, 0, 0, DateTimeKind.Unspecified), "Trasferta" },
                    { new Guid("1bada44d-bc5a-4c0a-babd-be4336abd201"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("1f04628f-a7cd-4407-abe9-c5fb429f0e18"), false, false, "trasferta", null, false, new DateTime(2024, 1, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "Trasferta" },
                    { new Guid("1fd64cb4-a2d8-4b05-9652-33e2a35af577"), false, false, "permesso", null, false, new DateTime(2024, 2, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 2, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), "Permesso" },
                    { new Guid("2d4e87c0-47fe-45c3-8ebd-90818506738f"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("3737ad68-5f67-4aaa-89e4-adbd072e59af"), false, false, "permesso", null, false, new DateTime(2024, 1, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), "Permesso" },
                    { new Guid("3904c044-b8d1-407a-b408-ef4205a1117f"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 11, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("4142060c-cb96-4797-a528-d5ada3648a22"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 17, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("4453240c-198c-404d-bbb3-aa272115e2cc"), false, false, "straordinario", null, false, new DateTime(2024, 1, 17, 23, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 17, 22, 0, 0, 0, DateTimeKind.Unspecified), "Straordinario" },
                    { new Guid("506bcd84-c88d-41ef-8bed-efab58a1b93b"), true, true, "rendicontazione", null, false, new DateTime(2024, 2, 7, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 2, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("52183a19-2f8c-4d62-8028-ae307fbe1665"), false, false, "permesso", null, false, new DateTime(2024, 1, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), "Permesso" },
                    { new Guid("5bca2818-3f30-4c96-9b38-cdcdd6eef3c1"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 17, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("5ff5678b-9c07-4775-a8c9-28f12249faa3"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 12, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("692d6168-5603-4ed7-9a10-8cd252d4750e"), false, false, "straordinario", null, false, new DateTime(2024, 1, 26, 20, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), "Straordinario" },
                    { new Guid("6ac20d92-6050-46b9-b62a-f845c8690f5e"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("6b12f417-224f-4964-b704-2f5014c59297"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("6fcba647-9774-45d1-b9ea-c8d33c3e346a"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("7c738465-495d-4770-97ce-0023e5da9aa2"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 11, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 11, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("7f400b10-c82c-42be-91ba-057f91c7250d"), false, false, "permesso", null, false, new DateTime(2024, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), "Permesso" },
                    { new Guid("8a84e9ce-dfca-4911-af3d-24b3c5671eed"), false, false, "trasferta", null, false, new DateTime(2024, 1, 16, 22, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), "Trasferta" },
                    { new Guid("8e06062f-8ecb-460a-98e6-7018cc4b0f68"), false, false, "libero", null, false, new DateTime(2024, 1, 21, 23, 59, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ferie" },
                    { new Guid("91341ec9-f97a-44aa-812d-693eb05a9dbe"), true, true, "libero", null, false, new DateTime(2024, 2, 4, 23, 59, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feria" },
                    { new Guid("98ba4c76-a205-45d5-965d-1e214d785d84"), false, false, "libero", null, false, new DateTime(2024, 1, 7, 23, 59, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vacanze" },
                    { new Guid("a35c1a6b-e7dc-4183-baf0-9951d1503007"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 10, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("a3b660d1-461a-4b25-af8e-73592d0da99f"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("a596ffaa-0eae-4aee-b178-b0b20e57d38e"), false, false, "libero", null, false, new DateTime(2024, 1, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), "Ferie" },
                    { new Guid("a95c5aa3-71ee-44a2-ac97-f3961ecf1727"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("bc87e827-241d-47bf-a02e-5b386a990d33"), false, false, "trasferta", null, false, new DateTime(2024, 1, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), "Trasferta" },
                    { new Guid("c292fb4a-2102-478f-b98d-2b695d597335"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 9, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("d14ea151-bb36-481c-989a-ed73700b0213"), false, false, "straordinario", null, false, new DateTime(2024, 1, 29, 22, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 29, 19, 0, 0, 0, DateTimeKind.Unspecified), "Straordinario" },
                    { new Guid("d8ff3076-cfb9-4d7b-a90e-c4ffcaf8fdf2"), false, false, "permesso", null, false, new DateTime(2024, 2, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 2, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), "Permesso" },
                    { new Guid("df94b160-4e26-4eba-b039-ee2df5e851a9"), true, true, "rendicontazione", null, false, new DateTime(2024, 2, 6, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 2, 6, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("e919393d-40a1-4ce1-b9b4-e336fcc6284d"), true, true, "rendicontazione", null, false, new DateTime(2024, 2, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 2, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("f4df6b14-3208-4b4b-ab01-1f7d80c50494"), false, false, "libero", null, false, new DateTime(2024, 1, 14, 23, 59, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Week-end" },
                    { new Guid("fdc86433-6a79-461c-951a-d8f80e0d0e17"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" }
                });

            migrationBuilder.InsertData(
                table: "Ferie",
                columns: new[] { "Id", "DataFine", "DataInizio", "Dettagli", "Durata" },
                values: new object[,]
                {
                    { new Guid("3da511ad-41de-4c7d-bc12-c212c9078c3c"), new DateTime(2024, 1, 21, 23, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ferie", 4 },
                    { new Guid("ba60bf9e-e974-4bdb-bf62-37495c967447"), new DateTime(2024, 1, 14, 23, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Week-end", 2 },
                    { new Guid("c58ee64d-759a-4027-be0e-70f10f3d6864"), new DateTime(2024, 1, 7, 23, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vacanza", 7 },
                    { new Guid("cebda61f-07f6-4bd5-b373-48c99d694aa1"), new DateTime(2024, 1, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di Ferie", 60 },
                    { new Guid("f5d34b3c-6464-4cf9-9282-06b8f4955ee3"), new DateTime(2024, 2, 4, 23, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ferie", 4 }
                });

            migrationBuilder.InsertData(
                table: "NottiFuori",
                columns: new[] { "Id", "Commessa", "Data", "Dettagli", "TipoViaggio" },
                values: new object[,]
                {
                    { new Guid("e826590d-467c-4ce8-b5d2-2ad369796c9a"), "Riparazione", new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Data la distanza tra l'azienda e cliente necessita di essere vicini per velocizzare la riparazione per il giorno dopo", "Lavoro" },
                    { new Guid("e8aec9db-23f6-4ac6-835f-59cec3a26862"), "Commessa di notte fuori", new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di notte fuori", "Lavoro" }
                });

            migrationBuilder.InsertData(
                table: "Permessi",
                columns: new[] { "Id", "Data", "Dettagli", "OraFine", "OraInizio", "OreTotali" },
                values: new object[,]
                {
                    { new Guid("1b812db9-c22f-4959-ad71-95bbdfe13d6d"), new DateTime(2024, 2, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), "Malattia", new DateTime(2024, 2, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), 180 },
                    { new Guid("5fc914a8-e7d9-471d-bb50-99dbc3b69bab"), new DateTime(2024, 2, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), "Malattia", new DateTime(2024, 2, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 240 },
                    { new Guid("ad585349-659f-4193-964c-7fb41c9f7ffd"), new DateTime(2024, 2, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), "Familiare", new DateTime(2024, 2, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), 180 },
                    { new Guid("c855aa2a-26a4-4d70-8e7a-4a766b486aba"), new DateTime(2024, 1, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), "Familiare", new DateTime(2024, 1, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), 180 },
                    { new Guid("f50602e4-3871-4239-b635-a5955ea26f75"), new DateTime(2024, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), "Medica", new DateTime(2024, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), 120 },
                    { new Guid("fed7594f-3738-4cb5-bc0f-a459aa37e58b"), new DateTime(2024, 1, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di permesso", new DateTime(2024, 1, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), 180 }
                });

            migrationBuilder.InsertData(
                table: "Rendicontazioni",
                columns: new[] { "Id", "Commessa", "Data", "Dettagli", "OraFine", "OraInizio", "OreTotali", "Straordinario" },
                values: new object[,]
                {
                    { new Guid("099c45c2-a0f3-440f-af72-c0db91721199"), "Commessa di rendicontazione", new DateTime(2024, 1, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di Rendicontazioni", new DateTime(2024, 1, 26, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, true },
                    { new Guid("14debad8-ec53-4bcd-8be4-2c15f8d8d538"), "Lavoro", new DateTime(2024, 2, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro", new DateTime(2024, 2, 7, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("154d54eb-06cd-42ed-a54b-0495b4b08859"), "Aggiustamento", new DateTime(2024, 2, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Aggiustamento ad un problema del cliente", new DateTime(2024, 2, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("1991f4fc-4a08-482d-b2f4-fa46c67250e6"), "Sistemazione", new DateTime(2024, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Sistemato un problema del cliente", new DateTime(2024, 1, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("44aabf16-1106-44d6-85ff-e2efe15c1a6c"), "Progetto", new DateTime(2024, 1, 29, 19, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro del progetto straordinario", new DateTime(2024, 1, 29, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 29, 19, 0, 0, 0, DateTimeKind.Unspecified), 3, true },
                    { new Guid("65fa6ad2-9b89-47d8-bce6-dab654bec07a"), "Lavoro", new DateTime(2024, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro", new DateTime(2024, 1, 12, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("66e679b9-c84b-4621-aada-461bc5931786"), "progetto", new DateTime(2024, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), "Elaborazione del progetto di gruppo", new DateTime(2024, 1, 11, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("6edb5652-ebc2-4f26-b7d4-80dc23ba3b04"), "progetto", new DateTime(2024, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), "Elaborazione del progetto di gruppo", new DateTime(2024, 1, 11, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("71a64413-52af-4008-bf9d-afed4288a177"), "Lavoro", new DateTime(2024, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro", new DateTime(2024, 1, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, true },
                    { new Guid("7c2446a2-db04-4ae0-a082-ee3fa21b2817"), "Progetto", new DateTime(2024, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pianificazione del progetto", new DateTime(2024, 1, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("822ae6e2-5bbf-47b6-b165-6aa432dc5e41"), "Lavoro", new DateTime(2024, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro per un progetto", new DateTime(2024, 1, 9, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("872004bc-fd9e-44e2-a3d5-5b3a9e89d926"), "Lavoro", new DateTime(2024, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro", new DateTime(2024, 1, 17, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, true },
                    { new Guid("89be85f1-df28-4e6f-81a4-55d1ce1b4e74"), "Progetto", new DateTime(2024, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pianificazione del progetto", new DateTime(2024, 1, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), 3, false },
                    { new Guid("918c0549-4f33-42a7-9e43-bc01200a2296"), "Lavoro", new DateTime(2024, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro per un progetto", new DateTime(2024, 1, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("99e58bad-c654-4c0d-b5a5-7703c69bf98b"), "Lavoro", new DateTime(2024, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro per un progetto di gruppo", new DateTime(2024, 1, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("affa3b81-ffc3-4e68-b379-4e06d69678ec"), "Progetto", new DateTime(2024, 2, 6, 14, 0, 0, 0, DateTimeKind.Unspecified), "Termine del progetto", new DateTime(2024, 2, 6, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 6, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("ba04406d-38f0-47c8-89c1-c538da1a7816"), "Lavoro", new DateTime(2024, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro", new DateTime(2024, 1, 17, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, true },
                    { new Guid("c22fded0-c7f9-4cb0-a5ee-6fe529843eff"), "Lavoro", new DateTime(2024, 1, 17, 22, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro", new DateTime(2024, 1, 17, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 17, 22, 0, 0, 0, DateTimeKind.Unspecified), 1, true },
                    { new Guid("c97faa20-ba64-4a05-8736-650c786461f5"), "Commessa di rendicontazione", new DateTime(2024, 1, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di Rendicontazioni", new DateTime(2024, 1, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, false },
                    { new Guid("e6080929-6b69-4e8f-9385-306a63de6e91"), "Lavoro", new DateTime(2024, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro per un progetto di gruppo", new DateTime(2024, 1, 10, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("eaf62043-d309-4575-bab2-d434cde2d21b"), "Commessa di rendicontazione", new DateTime(2024, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di Rendicontazioni", new DateTime(2024, 1, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, false },
                    { new Guid("ee9be0b6-cf5f-4f0a-875c-81b160d296f4"), "Sistemazione", new DateTime(2024, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Sistemato un problema del cliente", new DateTime(2024, 1, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("ef07bbe1-d7a2-437a-a6a4-253e3714e394"), "Lavoro", new DateTime(2024, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro", new DateTime(2024, 1, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, false }
                });

            migrationBuilder.InsertData(
                table: "Rimborsi",
                columns: new[] { "Id", "CartaAziendale", "Commessa", "Data", "Dettagli", "Importo" },
                values: new object[,]
                {
                    { new Guid("46909b40-6e92-42e8-b120-d1657f9e9c40"), true, "Riparazione", new DateTime(2024, 1, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), "Rimborso per il viaggio", 120 },
                    { new Guid("b5a65c24-ab43-44bc-a296-244b525b5d32"), false, "Commessa di rimborso", new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di rimborso", 100 },
                    { new Guid("e92a3649-ec84-4d1c-a0a2-c9053d2db8f5"), false, "Commessa di rimborso", new DateTime(2024, 1, 16, 22, 0, 0, 0, DateTimeKind.Unspecified), "Rimborso per il viaggio", 100 }
                });

            migrationBuilder.InsertData(
                table: "Trasferte",
                columns: new[] { "Id", "AutoAziendale", "Chilometri", "Commessa", "DataFine", "DataInizio", "Dettagli" },
                values: new object[,]
                {
                    { new Guid("8b72b6dd-3ed4-4f6e-bd6d-fc1d45da791f"), true, 350, "Riparazione", new DateTime(2024, 1, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "Riparazione ad un guasto ad un macchinario del cliente" },
                    { new Guid("98986b72-f25c-43b7-af3f-bb41244195e2"), false, 200, "Aggiornamento", new DateTime(2024, 1, 16, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 16, 6, 0, 0, 0, DateTimeKind.Unspecified), "Aggiornamento del sistema richiesto al cliente" },
                    { new Guid("c04c737a-2032-4680-ae6f-7072fe060085"), false, 200, "Commessa di Trasferte", new DateTime(2024, 1, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di Trasferte" }
                });

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
