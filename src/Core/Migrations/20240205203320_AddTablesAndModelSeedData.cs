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
                    { new Guid("00a1f0d7-706e-463f-8223-8f8dca3abdee"), false, false, "trasferta", null, false, new DateTime(2024, 1, 16, 22, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), "Trasferta" },
                    { new Guid("10257d78-d560-4701-9e9d-9ac707e70839"), false, false, "libero", null, false, new DateTime(2024, 1, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), "Ferie" },
                    { new Guid("10f70e12-5ae5-47d3-ba20-e09f6824df33"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("110996c4-e104-4b62-af8c-1bc94f2338f5"), true, true, "rendicontazione", null, false, new DateTime(2024, 2, 6, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 2, 6, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("1abbf3a3-62f4-472d-bdab-636c8ba06553"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 12, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("1cffbb60-452c-40ad-94da-ff8564cfbe05"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("231a1d13-e539-4902-ab86-c80080a072ac"), false, false, "straordinario", null, false, new DateTime(2024, 1, 26, 20, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), "Straordinario" },
                    { new Guid("30149fb0-e5cb-488f-843a-1e14e8e11eb8"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("332b3702-b23c-4d1c-b7c4-fee6b82a22b9"), false, false, "permesso", null, false, new DateTime(2024, 2, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 2, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), "Permesso" },
                    { new Guid("3b0bea7e-24f5-42ea-8f33-3489140cb143"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("3f2eed58-1a35-49d9-871c-343c680e692b"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("4788e4b1-01ba-4445-bbd3-6f4e9589c756"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("4870820b-2740-49ab-88cc-dddda258fd96"), true, true, "libero", null, false, new DateTime(2024, 2, 4, 23, 59, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feria" },
                    { new Guid("50efddd8-e3c5-4c3c-bb0d-df2a9d3a1c6c"), false, false, "libero", null, false, new DateTime(2024, 1, 14, 23, 59, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Week-end" },
                    { new Guid("592850bb-6cff-486d-ae89-d74b4e6902fa"), false, false, "straordinario", null, false, new DateTime(2024, 1, 17, 23, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 17, 22, 0, 0, 0, DateTimeKind.Unspecified), "Straordinario" },
                    { new Guid("5b11ac79-e032-45aa-80cb-969ada2fad71"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 11, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 11, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("5becb32b-accd-473d-8be7-201c4823a6b5"), false, false, "trasferta", null, false, new DateTime(2024, 1, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "Trasferta" },
                    { new Guid("5d4732ff-4530-4b98-93d3-e309f4cb9436"), false, false, "libero", null, false, new DateTime(2024, 1, 21, 23, 59, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ferie" },
                    { new Guid("714927af-4103-4b2b-9117-b6fac960f3db"), false, false, "trasferta", null, false, new DateTime(2024, 1, 16, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 16, 6, 0, 0, 0, DateTimeKind.Unspecified), "Trasferta" },
                    { new Guid("765929b8-b37f-450b-a1b1-895ae26b9ed3"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("8113fea2-ed4e-459c-bbe3-48b4358a3dea"), false, false, "permesso", null, false, new DateTime(2024, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), "Permesso" },
                    { new Guid("81b4d0d2-8cbb-4ba4-bb1a-ef3aa7b94b3e"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 11, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("8b0471f6-dd91-4dde-96d7-faa8abdda0e5"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 17, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("9173f3a6-56a5-4636-9305-4e5af3dd97c7"), false, false, "permesso", null, false, new DateTime(2024, 1, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), "Permesso" },
                    { new Guid("956dfb30-829a-435a-bba1-03d7dd68de3d"), false, false, "straordinario", null, false, new DateTime(2024, 1, 29, 22, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 29, 19, 0, 0, 0, DateTimeKind.Unspecified), "Straordinario" },
                    { new Guid("96a49e7d-92fa-4221-b9bb-f23ccbe5b366"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 10, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("ac99fd17-c655-409d-9721-dcff48fef6cc"), false, false, "permesso", null, false, new DateTime(2024, 1, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), "Permesso" },
                    { new Guid("b27b71af-c694-459e-a53d-1360383c9b5e"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("bec85dbc-38de-4e1d-8f18-7b6dc2bff6b8"), false, false, "permesso", null, false, new DateTime(2024, 2, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 2, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), "Permesso" },
                    { new Guid("bf8eb095-b7c5-4e25-950f-4b03c4fcca89"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 17, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("c022be25-4a21-47dc-9494-edacdb10bdad"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("c825a0c9-08b6-4feb-8355-85aa6e7cc870"), false, false, "permesso", null, false, new DateTime(2024, 2, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 2, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), "Permesso" },
                    { new Guid("d24db327-0080-4524-929a-d47fb13230c9"), true, true, "rendicontazione", null, false, new DateTime(2024, 2, 7, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 2, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("d978dab1-f896-4b3d-a562-0a77708b6259"), true, true, "rendicontazione", null, false, new DateTime(2024, 2, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 2, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("dc941a37-eb4b-4435-8485-4476652dd10e"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 9, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("e191a1e6-a72a-4155-a66f-49f18558f076"), false, false, "trasferta", null, false, new DateTime(2024, 1, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), "Trasferta" },
                    { new Guid("f830fc03-c805-46d1-b234-ecd0af5f6154"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione" },
                    { new Guid("fbc4d833-dedb-46e0-97ec-0c7f8762126f"), false, false, "libero", null, false, new DateTime(2024, 1, 7, 23, 59, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vacanze" }
                });

            migrationBuilder.InsertData(
                table: "Ferie",
                columns: new[] { "Id", "DataFine", "DataInizio", "Dettagli", "Durata" },
                values: new object[,]
                {
                    { new Guid("035463c9-2fe9-4302-9831-33e2f91fe86b"), new DateTime(2024, 1, 7, 23, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vacanza", 7 },
                    { new Guid("1cff505e-0e61-466b-b909-2aa7b2c52a59"), new DateTime(2024, 2, 4, 23, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ferie", 4 },
                    { new Guid("c4f1d856-e2d9-4179-89c4-69a0766143bf"), new DateTime(2024, 1, 14, 23, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Week-end", 2 },
                    { new Guid("ea707300-a3ea-4727-b84b-2632a765226e"), new DateTime(2024, 1, 21, 23, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ferie", 4 },
                    { new Guid("ed542edf-f36a-44ab-87f6-f835adf7fe85"), new DateTime(2024, 1, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di Ferie", 60 }
                });

            migrationBuilder.InsertData(
                table: "NottiFuori",
                columns: new[] { "Id", "Commessa", "Data", "Dettagli", "TipoViaggio" },
                values: new object[,]
                {
                    { new Guid("4fa4b603-cb2d-4abd-905b-85287d772a0b"), "Commessa di notte fuori", new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di notte fuori", "Lavoro" },
                    { new Guid("c761763c-3c86-4e72-94bd-ad9939f8a88a"), "Riparazione", new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Data la distanza tra l'azienda e cliente necessita di essere vicini per velocizzare la riparazione per il giorno dopo", "Lavoro" }
                });

            migrationBuilder.InsertData(
                table: "Permessi",
                columns: new[] { "Id", "Data", "Dettagli", "Durata", "OraFine", "OraInizio" },
                values: new object[,]
                {
                    { new Guid("1083cffd-f10c-4694-8791-1189127e761b"), new DateTime(2024, 1, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di permesso", 180, new DateTime(2024, 1, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 26, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("120c6305-502e-4c00-a191-b04e056db371"), new DateTime(2024, 2, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), "Malattia", 240, new DateTime(2024, 2, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 5, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("27f4e6d2-867a-4dd9-9272-5b5f4ef25211"), new DateTime(2024, 2, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), "Familiare", 180, new DateTime(2024, 2, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 7, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3349d448-afeb-4910-a8d9-9056c672d7a6"), new DateTime(2024, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), "Medica", 120, new DateTime(2024, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4998f3e3-b706-404a-8cb8-f8651fd6a23b"), new DateTime(2024, 2, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), "Malattia", 180, new DateTime(2024, 2, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 6, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f15cbbfe-22be-4e93-b89d-1226428d4922"), new DateTime(2024, 1, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), "Familiare", 180, new DateTime(2024, 1, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Rendicontazioni",
                columns: new[] { "Id", "Commessa", "Data", "Dettagli", "OraFine", "OraInizio", "OreTotali", "Straordinario" },
                values: new object[,]
                {
                    { new Guid("034bfb43-d9b9-4904-b947-17aa19955886"), "progetto", new DateTime(2024, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), "Elaborazione del progetto di gruppo", new DateTime(2024, 1, 11, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("0cf695cb-1452-4c0d-897f-3530da0a8c5d"), "Progetto", new DateTime(2024, 2, 6, 14, 0, 0, 0, DateTimeKind.Unspecified), "Termine del progetto", new DateTime(2024, 2, 6, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 6, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("2043a196-e0e1-44cb-af46-ab6617fdbc2b"), "Progetto", new DateTime(2024, 1, 29, 19, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro del progetto straordinario", new DateTime(2024, 1, 29, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 29, 19, 0, 0, 0, DateTimeKind.Unspecified), 3, true },
                    { new Guid("247ff325-479f-4d81-a826-8124e6fbd155"), "Lavoro", new DateTime(2024, 1, 17, 22, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro", new DateTime(2024, 1, 17, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 17, 22, 0, 0, 0, DateTimeKind.Unspecified), 1, true },
                    { new Guid("549945c2-1e36-4884-b281-3a8459cd08bd"), "Commessa di rendicontazione", new DateTime(2024, 1, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di Rendicontazioni", new DateTime(2024, 1, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, false },
                    { new Guid("62fda361-35df-48d1-a101-596e732b094b"), "Sistemazione", new DateTime(2024, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Sistemato un problema del cliente", new DateTime(2024, 1, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("68989d6b-ddcd-4ac2-b341-efcdcd535abf"), "progetto", new DateTime(2024, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), "Elaborazione del progetto di gruppo", new DateTime(2024, 1, 11, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("6aff4535-b290-427a-9b40-3b36c034f4c3"), "Lavoro", new DateTime(2024, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro", new DateTime(2024, 1, 17, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, true },
                    { new Guid("6b5b46e6-a48a-43b2-b0be-7adfbe083385"), "Commessa di rendicontazione", new DateTime(2024, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di Rendicontazioni", new DateTime(2024, 1, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, false },
                    { new Guid("707eceef-d9ec-4d2c-a082-946a6a848d0e"), "Aggiustamento", new DateTime(2024, 2, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Aggiustamento ad un problema del cliente", new DateTime(2024, 2, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("9282f878-81f8-4734-b3a3-84da8719ac85"), "Lavoro", new DateTime(2024, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro", new DateTime(2024, 1, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("9b86d36d-1c39-455a-aad7-1f55b8719aab"), "Sistemazione", new DateTime(2024, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Sistemato un problema del cliente", new DateTime(2024, 1, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("a5f2d0cf-5ef3-4cef-8e5f-56c29a69b9f0"), "Lavoro", new DateTime(2024, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro", new DateTime(2024, 1, 17, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, true },
                    { new Guid("b58b2163-86bd-407b-b863-6b2e4c97c988"), "Lavoro", new DateTime(2024, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro per un progetto di gruppo", new DateTime(2024, 1, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("bf824391-ff81-4185-b101-d7d8571fcb6f"), "Lavoro", new DateTime(2024, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro", new DateTime(2024, 1, 12, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("c5ebe7dc-5629-41c6-803a-772d40ff67ad"), "Lavoro", new DateTime(2024, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro per un progetto", new DateTime(2024, 1, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("c774480a-f7a1-48e1-9e75-455207e89e16"), "Progetto", new DateTime(2024, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pianificazione del progetto", new DateTime(2024, 1, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("cd3816b4-45c7-42c2-8864-d5238c6f1c50"), "Commessa di rendicontazione", new DateTime(2024, 1, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di Rendicontazioni", new DateTime(2024, 1, 26, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, true },
                    { new Guid("d5842dab-7975-4d46-8495-df23279e79c9"), "Progetto", new DateTime(2024, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pianificazione del progetto", new DateTime(2024, 1, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), 3, false },
                    { new Guid("de13d3bd-ed34-4593-ba4d-15a2ef212416"), "Lavoro", new DateTime(2024, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro per un progetto di gruppo", new DateTime(2024, 1, 10, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("e8313311-2ded-4821-a7d3-b24f54da70b5"), "Lavoro", new DateTime(2024, 2, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro", new DateTime(2024, 2, 7, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("f6f13114-21aa-4333-a646-44d578ed4116"), "Lavoro", new DateTime(2024, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro per un progetto", new DateTime(2024, 1, 9, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("fa0c62fd-3a81-4bb2-a931-2ef684cf5db4"), "Lavoro", new DateTime(2024, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro", new DateTime(2024, 1, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, true }
                });

            migrationBuilder.InsertData(
                table: "Rimborsi",
                columns: new[] { "Id", "CartaAziendale", "Commessa", "Data", "Dettagli", "Importo" },
                values: new object[,]
                {
                    { new Guid("32c6a286-b822-4e54-b6f2-4fd5e90e9b82"), false, "Commessa di rimborso", new DateTime(2024, 1, 16, 22, 0, 0, 0, DateTimeKind.Unspecified), "Rimborso per il viaggio", 100 },
                    { new Guid("c177bef6-cfe0-442f-9d04-41c8f7f8a105"), false, "Commessa di rimborso", new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di rimborso", 100 },
                    { new Guid("e4729c5c-df86-4983-98cc-1a0dd9555640"), true, "Riparazione", new DateTime(2024, 1, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), "Rimborso per il viaggio", 120 }
                });

            migrationBuilder.InsertData(
                table: "Trasferte",
                columns: new[] { "Id", "AutoAziendale", "Chilometri", "Commessa", "DataFine", "DataInizio", "Dettagli" },
                values: new object[,]
                {
                    { new Guid("7657b97b-52e5-4d8b-b55b-a2c98ae25aad"), false, 200, "Commessa di Trasferte", new DateTime(2024, 1, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), "Dettagli di Trasferte" },
                    { new Guid("9b6a3cec-bc36-4fd8-9201-cf17523a38a0"), true, 350, "Riparazione", new DateTime(2024, 1, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "Riparazione ad un guasto ad un macchinario del cliente" },
                    { new Guid("ef4e9192-c547-4ec4-bd2b-c8ad238edb60"), false, 200, "Aggiornamento", new DateTime(2024, 1, 16, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 16, 6, 0, 0, 0, DateTimeKind.Unspecified), "Aggiornamento del sistema richiesto al cliente" }
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
