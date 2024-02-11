using System;
using Core.Infrastructure;
using Core.Models;
using Core.Services.Shared;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Services
{
    public class TemplateDbContext : DbContext
    {
        public TemplateDbContext()
        {
        }

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var rendicontazioneId1 = Guid.NewGuid();
            var rendicontazioneId2 = Guid.NewGuid();
            var rendicontazioneId3 = Guid.NewGuid();
            var rendicontazioneId4 = Guid.NewGuid();

            var permessoId1 = Guid.NewGuid();
            var trasfertaId1 = Guid.NewGuid();
            var feriaId1 = Guid.NewGuid();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    Email = "email1@test.it",
                    Password = "M0Cuk9OsrcS/rTLGf5SY6DUPqU2rGc1wwV2IL88GVGo=",
                    FirstName = "Nome1",
                    LastName = "Cognome1",
                    NickName = "Nickname1"
                },
                new User
                {
                    Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"),
                    Email = "email2@test.it",
                    Password = "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=",
                    FirstName = "Nome2",
                    LastName = "Cognome2",
                    NickName = "Nickname2"
                },
                new User
                {
                    Id = Guid.Parse("bfdef48b-c7ea-4227-8333-c635af267354"),
                    Email = "email3@test.it",
                    Password = "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=",
                    FirstName = "Nome3",
                    LastName = "Cognome3",
                    NickName = "Nickname3"
                }
                );

            modelBuilder.Entity<VueCalEvent>().HasData(
                // 8 Gennaio (Rendicontazione)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 8, 9, 0, 0),
                    End = new DateTime(2024, 1, 8, 13, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false,
                    RendicontazioneId = rendicontazioneId1,
                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 8, 14, 0, 0),
                    End = new DateTime(2024, 1, 8, 18, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false,
                    RendicontazioneId = rendicontazioneId2,
                },

                // 9 Gennaio (Rendicontazione)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 9, 9, 0, 0),
                    End = new DateTime(2024, 1, 9, 13, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false,
                    RendicontazioneId = rendicontazioneId3,
                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 9, 14, 0, 0),
                    End = new DateTime(2024, 1, 9, 18, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false,
                    RendicontazioneId = rendicontazioneId4,
                },

                //Trasferta 16 Gennaio
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 16, 14, 0, 0),
                    End = new DateTime(2024, 1, 16, 22, 0, 0),
                    Title = "Trasferta",
                    Content = null,
                    Class = "trasferta",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false,
                    TrasfertaId = trasfertaId1,
                },

                //Permesso 15 Gennaio
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 15, 14, 0, 0),
                    End = new DateTime(2024, 1, 15, 16, 0, 0),
                    Title = "Permesso",
                    Content = null,
                    Class = "permesso",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false,
                    PermessoId = permessoId1,
                },

                //Feria 17-19 Gennaio
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 17, 0, 0, 0),
                    End = new DateTime(2024, 1, 19, 23, 59, 0),
                    Title = "Vacanze",
                    Content = null,
                    Class = "libero",
                    Background = false,
                    Split = "",
                    AllDay = true,
                    Deletable = false,
                    Resizable = false,
                    FeriaId = feriaId1,
                }
                );

            modelBuilder.Entity<Rendicontazione>().HasData(
                // Rendicontazione 8 Gennaio
                new Rendicontazione
                {
                    Id = rendicontazioneId1,
                    OreTotali = 4,
                    Data = new DateTime(2024, 1, 8, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 8, 9, 0, 0),
                    OraFine = new DateTime(2024, 1, 8, 13, 0, 0),
                    Straordinario = false,
                    Commessa = "Sistemazione",
                    Dettagli = "Sistemato un problema del cliente"
                },

                new Rendicontazione
                {
                    Id = rendicontazioneId2,
                    OreTotali = 4,
                    Data = new DateTime(2024, 1, 8, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 8, 14, 0, 0),
                    OraFine = new DateTime(2024, 1, 8, 18, 0, 0),
                    Straordinario = false,
                    Commessa = "Sistemazione",
                    Dettagli = "Sistemato un problema del cliente"
                },

                // Rendicontazione 9 Gennaio
                new Rendicontazione
                {
                    Id = rendicontazioneId3,
                    OreTotali = 4,
                    Data = new DateTime(2024, 1, 9, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 9, 9, 0, 0),
                    OraFine = new DateTime(2024, 1, 9, 13, 0, 0),
                    Straordinario = false,
                    Commessa = "Lavoro",
                    Dettagli = "Lavoro per un progetto"
                },

                new Rendicontazione
                {
                    Id = rendicontazioneId4,
                    OreTotali = 4,
                    Data = new DateTime(2024, 1, 9, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 9, 14, 0, 0),
                    OraFine = new DateTime(2024, 1, 9, 18, 0, 0),
                    Straordinario = false,
                    Commessa = "Lavoro",
                    Dettagli = "Lavoro per un progetto",
                }
                );

            modelBuilder.Entity<Trasferta>().HasData(
                // Trasferta 16 Gennaio
                new Trasferta
                {
                    Id = trasfertaId1,
                    Chilometri = 200,
                    DataInizio = new DateTime(2024, 1, 16, 14, 0, 0),
                    OraInizio = new DateTime(2024, 1, 16, 14, 0, 0),
                    OraFine = new DateTime(2024, 1, 16, 22, 0, 0),
                    DataFine = new DateTime(2024, 1, 16, 22, 0, 0),
                    Commessa = "Aggiornamento",
                    AutoAziendale = false,
                    Dettagli = "Migliorie al sistema richiesto dal cliente"
                }
                );

            modelBuilder.Entity<Permesso>().HasData(
                // Permesso 15 Gennaio
                new Permesso
                {
                    Id = permessoId1,
                    Data = new DateTime(2024, 1, 15, 14, 0, 0),
                    OraInizio = new DateTime(2024, 1, 15, 14, 0, 0),
                    OraFine = new DateTime(2024, 1, 15, 16, 0, 0),
                    OreTotali = 120,
                    Dettagli = "Personali",
                }
                );

            modelBuilder.Entity<Feria>().HasData(
                //Feria 17-19 Gennaio
                new Feria
                {
                    Id = feriaId1,
                    DataInizio = new DateTime(2024, 1, 17, 0, 0, 0),
                    DataFine = new DateTime(2024, 1, 19, 23, 59, 0),
                    Durata = 3,
                    Dettagli = "Vacanza",
                }
                );
        }
        public DbSet<User> Users { get; set; }
        public DbSet<VueCalEvent> Eventi { get; set; }
        public DbSet<Rendicontazione> Rendicontazioni { get; set; } //manca gestire lo straordinario
        public DbSet<Permesso> Permessi { get; set; }
        public DbSet<Feria> Ferie { get; set; }
        public DbSet<NotteFuori> NottiFuori { get; set; }//manca
        public DbSet<Trasferta> Trasferte { get; set; }
        public DbSet<Rimborso> Rimborsi { get; set; } //manca
    }
}