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
                    OraInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OraFine = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    Resizable = table.Column<bool>(type: "bit", nullable: true),
                    RendicontazioneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FeriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PermessoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrasfertaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventi_Ferie_FeriaId",
                        column: x => x.FeriaId,
                        principalTable: "Ferie",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Eventi_Permessi_PermessoId",
                        column: x => x.PermessoId,
                        principalTable: "Permessi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Eventi_Rendicontazioni_RendicontazioneId",
                        column: x => x.RendicontazioneId,
                        principalTable: "Rendicontazioni",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Eventi_Trasferte_TrasfertaId",
                        column: x => x.TrasfertaId,
                        principalTable: "Trasferte",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Ferie",
                columns: new[] { "Id", "DataFine", "DataInizio", "Dettagli", "Durata" },
                values: new object[] { new Guid("1b75d75e-b75a-41d4-bbad-d2b2622b8dd3"), new DateTime(2024, 1, 19, 23, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vacanza", 3 });

            migrationBuilder.InsertData(
                table: "Permessi",
                columns: new[] { "Id", "Data", "Dettagli", "OraFine", "OraInizio", "OreTotali" },
                values: new object[] { new Guid("eea1f511-111c-41a6-9905-c3b06b88c952"), new DateTime(2024, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), "Personali", new DateTime(2024, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), 120 });

            migrationBuilder.InsertData(
                table: "Rendicontazioni",
                columns: new[] { "Id", "Commessa", "Data", "Dettagli", "OraFine", "OraInizio", "OreTotali", "Straordinario" },
                values: new object[,]
                {
                    { new Guid("5ce24d8d-38d4-4efe-b53e-2f82c236bb35"), "Sistemazione", new DateTime(2024, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Sistemato un problema del cliente", new DateTime(2024, 1, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("5ffb43c1-9bd0-4752-951b-508f2293b7a6"), "Lavoro", new DateTime(2024, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro per un progetto", new DateTime(2024, 1, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("b3ca179a-d061-4fb9-a3db-fc9a5154b61b"), "Sistemazione", new DateTime(2024, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Sistemato un problema del cliente", new DateTime(2024, 1, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new Guid("dad29b8d-9c34-4721-81f2-e289c3c82633"), "Lavoro", new DateTime(2024, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), "Lavoro per un progetto", new DateTime(2024, 1, 9, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, false }
                });

            migrationBuilder.InsertData(
                table: "Trasferte",
                columns: new[] { "Id", "AutoAziendale", "Chilometri", "Commessa", "DataFine", "DataInizio", "Dettagli", "OraFine", "OraInizio" },
                values: new object[] { new Guid("c08e3de1-e26b-4f01-81f0-fbca477186e3"), false, 200, "Aggiornamento", new DateTime(2024, 1, 16, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), "Migliorie al sistema richiesto dal cliente", new DateTime(2024, 1, 16, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 16, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "NickName", "Password" },
                values: new object[,]
                {
                    { new Guid("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), "email1@test.it", "Nome1", "Cognome1", "Nickname1", "M0Cuk9OsrcS/rTLGf5SY6DUPqU2rGc1wwV2IL88GVGo=" },
                    { new Guid("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), "email2@test.it", "Nome2", "Cognome2", "Nickname2", "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=" },
                    { new Guid("bfdef48b-c7ea-4227-8333-c635af267354"), "email3@test.it", "Nome3", "Cognome3", "Nickname3", "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=" }
                });

            migrationBuilder.InsertData(
                table: "Eventi",
                columns: new[] { "Id", "AllDay", "Background", "Class", "Content", "Deletable", "End", "FeriaId", "PermessoId", "RendicontazioneId", "Resizable", "Split", "Start", "Title", "TrasfertaId" },
                values: new object[,]
                {
                    { new Guid("0bcda651-a068-4bda-9e1b-b8704fbe765e"), true, false, "libero", null, false, new DateTime(2024, 1, 19, 23, 59, 0, 0, DateTimeKind.Unspecified), new Guid("1b75d75e-b75a-41d4-bbad-d2b2622b8dd3"), null, null, false, "", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vacanze", null },
                    { new Guid("69cc76c3-2e50-4905-8b65-5c7b035108f1"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b3ca179a-d061-4fb9-a3db-fc9a5154b61b"), false, "", new DateTime(2024, 1, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione", null },
                    { new Guid("949ff5fa-94a3-46ca-9003-83dcd3fceb46"), false, false, "permesso", null, false, new DateTime(2024, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("eea1f511-111c-41a6-9905-c3b06b88c952"), null, false, "", new DateTime(2024, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), "Permesso", null },
                    { new Guid("c9490559-bf12-4d93-878f-f3226b2143e0"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("5ffb43c1-9bd0-4752-951b-508f2293b7a6"), false, "", new DateTime(2024, 1, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione", null },
                    { new Guid("dd00d06c-dd44-49a0-b2c2-3e6150f808b7"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("5ce24d8d-38d4-4efe-b53e-2f82c236bb35"), false, "", new DateTime(2024, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione", null },
                    { new Guid("ec5ea470-d727-41d2-9759-cf4a89c7020b"), false, false, "trasferta", null, false, new DateTime(2024, 1, 16, 22, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, "", new DateTime(2024, 1, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), "Trasferta", new Guid("c08e3de1-e26b-4f01-81f0-fbca477186e3") },
                    { new Guid("ed4e60ed-10c0-4ce4-a169-7914104349cf"), false, false, "rendicontazione", null, false, new DateTime(2024, 1, 9, 13, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("dad29b8d-9c34-4721-81f2-e289c3c82633"), false, "", new DateTime(2024, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rendicontazione", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventi_FeriaId",
                table: "Eventi",
                column: "FeriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventi_PermessoId",
                table: "Eventi",
                column: "PermessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventi_RendicontazioneId",
                table: "Eventi",
                column: "RendicontazioneId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventi_TrasfertaId",
                table: "Eventi",
                column: "TrasfertaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventi");

            migrationBuilder.DropTable(
                name: "NottiFuori");

            migrationBuilder.DropTable(
                name: "Rimborsi");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ferie");

            migrationBuilder.DropTable(
                name: "Permessi");

            migrationBuilder.DropTable(
                name: "Rendicontazioni");

            migrationBuilder.DropTable(
                name: "Trasferte");
        }
    }
}
