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

                // dal 1 al 7 Gennaio (Vacanza)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 1, 0, 0, 0),
                    End = new DateTime(2024, 1, 7, 23, 59, 0),
                    Title = "Vacanze",
                    Content = null,
                    Class = "libero",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },

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
                    Resizable = false
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
                    Resizable = false
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
                    Resizable = false
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
                    Resizable = false
                },

                // 10 Gennaio (Rendicontazione)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 10, 9, 0, 0),
                    End = new DateTime(2024, 1, 10, 13, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 10, 14, 0, 0),
                    End = new DateTime(2024, 1, 10, 18, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },

                // 11 Gennaio (Rendicontazione)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 11, 9, 0, 0),
                    End = new DateTime(2024, 1, 11, 13, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 11, 14, 0, 0),
                    End = new DateTime(2024, 1, 11, 18, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },

                // 12 Gennaio (Rendicontazione)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 12, 9, 0, 0),
                    End = new DateTime(2024, 1, 12, 13, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 12, 14, 0, 0),
                    End = new DateTime(2024, 1, 12, 18, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },

                // 13 e 14 Gennaio (Week-end)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 13, 0, 0, 0),
                    End = new DateTime(2024, 1, 14, 23, 59, 0),
                    Title = "Week-end",
                    Content = null,
                    Class = "libero",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },


                // 15 Gennaio (Rendicontazione-Permesso-Rendicontazione)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 15, 9, 0, 0),
                    End = new DateTime(2024, 1, 15, 13, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },
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
                    Resizable = false
                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 15, 16, 0, 0),
                    End = new DateTime(2024, 1, 15, 19, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },

                // 16 Gennaio (Trasferta)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 16, 6, 0, 0),
                    End = new DateTime(2024, 1, 16, 13, 0, 0),
                    Title = "Trasferta",
                    Content = null,
                    Class = "trasferta",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },
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
                    Resizable = false
                },

                // 17 Gennaio (Rendicontazione-Straordinario)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 17, 9, 0, 0),
                    End = new DateTime(2024, 1, 17, 13, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 17, 14, 0, 0),
                    End = new DateTime(2024, 1, 17, 18, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 17, 22, 0, 0),
                    End = new DateTime(2024, 1, 17, 23, 0, 0),
                    Title = "Straordinario",
                    Content = null,
                    Class = "straordinario",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },

                // dal 18 al 21 Gennaio (Ferie)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 18, 0, 0, 0),
                    End = new DateTime(2024, 1, 21, 23, 59, 0),
                    Title = "Ferie",
                    Content = null,
                    Class = "libero",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },

                // Prova 26 Gennaio
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 26, 9, 0, 0),
                    End = new DateTime(2024, 1, 26, 11, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 26, 11, 0, 0),
                    End = new DateTime(2024, 1, 26, 13, 0, 0),
                    Title = "Permesso",
                    Content = null,
                    Class = "permesso",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false

                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 26, 13, 0, 0),
                    End = new DateTime(2024, 1, 26, 15, 0, 0),
                    Title = "Ferie",
                    Content = null,
                    Class = "libero",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 26, 15, 0, 0),
                    End = new DateTime(2024, 1, 26, 17, 0, 0),
                    Title = "Trasferta",
                    Content = null,
                    Class = "trasferta",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false

                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 26, 17, 0, 0),
                    End = new DateTime(2024, 1, 26, 18, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 26, 18, 0, 0),
                    End = new DateTime(2024, 1, 26, 20, 0, 0),
                    Title = "Straordinario",
                    Content = null,
                    Class = "straordinario",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },

                // 27 e 28 Gennaio (Trasferta)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 27, 9, 0, 0),
                    End = new DateTime(2024, 1, 28, 19, 0, 0),
                    Title = "Trasferta",
                    Content = null,
                    Class = "trasferta",
                    Background = false,
                    Split="",
                    AllDay=false,
                    Deletable=false,
                    Resizable=false

                },

                // 29 Gennaio (Rendicontazione-Permesso-Straordinario)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 29, 9, 0, 0),
                    End = new DateTime(2024, 1, 29, 12, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = false,
                    Split="",
                    AllDay=false,
                    Deletable=false,
                    Resizable=false
                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 29, 14, 0, 0),
                    End = new DateTime(2024, 1, 29, 17, 0, 0),
                    Title = "Permesso",
                    Content = null,
                    Class = "permesso",
                    Background = false,
                    Split="",
                    AllDay=false,
                    Deletable=false,
                    Resizable=false

                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 29, 19, 0, 0),
                    End = new DateTime(2024, 1, 29, 22, 0, 0),
                    Title = "Straordinario",
                    Content = null,
                    Class = "straordinario",
                    Background = false,
                    Split="",
                    AllDay=false,
                    Deletable=false,
                    Resizable=false

                },

                
                // dall'1 al 4 Febbraio (Ferie)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 2, 1, 0, 0, 0),
                    End = new DateTime(2024, 2, 4, 23, 59, 0),
                    Title = "Feria",
                    Content = null,
                    Class = "libero",
                    Background = true,
                    Split="",
                    AllDay=true,
                    Deletable=false,
                    Resizable=false

                },

                // 5 Febbraio (Rendicontazione-Permesso)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 2, 5, 9, 0, 0),
                    End = new DateTime(2024, 2, 5, 13, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = true,
                    Split = "",
                    AllDay = true,
                    Deletable = false,
                    Resizable = false

                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 2, 5, 14, 0, 0),
                    End = new DateTime(2024, 2, 5, 18, 0, 0),
                    Title = "Permesso",
                    Content = null,
                    Class = "permesso",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },

                // 6 Febbraio (Permesso-Rendicontazione)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 2, 6, 9, 0, 0),
                    End = new DateTime(2024, 2, 6, 13, 0, 0),
                    Title = "Permesso",
                    Content = null,
                    Class = "permesso",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 2, 6, 14, 0, 0),
                    End = new DateTime(2024, 2, 6, 18, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = true,
                    Split = "",
                    AllDay = true,
                    Deletable = false,
                    Resizable = false

                },

                // 7 Febbraio (Permesso-Rendicontazione)
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 2, 7, 9, 0, 0),
                    End = new DateTime(2024, 2, 7, 13, 0, 0),
                    Title = "Permesso",
                    Content = null,
                    Class = "permesso",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = false,
                    Resizable = false
                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 2, 7, 14, 0, 0),
                    End = new DateTime(2024, 2, 7, 18, 0, 0),
                    Title = "Rendicontazione",
                    Content = null,
                    Class = "rendicontazione",
                    Background = true,
                    Split = "",
                    AllDay = true,
                    Deletable = false,
                    Resizable = false

                }

                );


            modelBuilder.Entity<Rendicontazione>().HasData(

                // Rendicontazione 8 Gennaio
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
                    OreTotali = 4,
                    Data = new DateTime(2024, 1, 9, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 9, 14, 0, 0),
                    OraFine = new DateTime(2024, 1, 9, 18, 0, 0),
                    Straordinario = false,
                    Commessa = "Lavoro",
                    Dettagli = "Lavoro per un progetto"
                },

                // Rendicontazione 10 Gennaio
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 4,
                    Data = new DateTime(2024, 1, 10, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 10, 9, 0, 0),
                    OraFine = new DateTime(2024, 1, 10, 13, 0, 0),
                    Straordinario = false,
                    Commessa = "Lavoro",
                    Dettagli = "Lavoro per un progetto di gruppo"
                },
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 4,
                    Data = new DateTime(2024, 1, 10, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 10, 14, 0, 0),
                    OraFine = new DateTime(2024, 1, 10, 18, 0, 0),
                    Straordinario = false,
                    Commessa = "Lavoro",
                    Dettagli = "Lavoro per un progetto di gruppo"
                },

                // Rendicontazione 11 Gennaio
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 4,
                    Data = new DateTime(2024, 1, 11, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 11, 9, 0, 0),
                    OraFine = new DateTime(2024, 1, 11, 13, 0, 0),
                    Straordinario = false,
                    Commessa = "progetto",
                    Dettagli = "Elaborazione del progetto di gruppo"
                },
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 4,
                    Data = new DateTime(2024, 1, 11, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 11, 14, 0, 0),
                    OraFine = new DateTime(2024, 1, 11, 18, 0, 0),
                    Straordinario = false,
                    Commessa = "progetto",
                    Dettagli = "Elaborazione del progetto di gruppo"
                },

                // Rendicontazione 12 Gennaio
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 4,
                    Data = new DateTime(2024, 1, 12, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 12, 9, 0, 0),
                    OraFine = new DateTime(2024, 1, 12, 13, 0, 0),
                    Straordinario = false,
                    Commessa = "Lavoro",
                    Dettagli = "Lavoro"
                },
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 4,
                    Data = new DateTime(2024, 1, 12, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 12, 14, 0, 0),
                    OraFine = new DateTime(2024, 1, 12, 18, 0, 0),
                    Straordinario = false,
                    Commessa = "Lavoro",
                    Dettagli = "Lavoro"
                },

                // Rendicontazione 15 Gennaio
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 4,
                    Data = new DateTime(2024, 1, 15, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 15, 9, 0, 0),
                    OraFine = new DateTime(2024, 1, 15, 13, 0, 0),
                    Straordinario = false,
                    Commessa = "Progetto",
                    Dettagli = "Pianificazione del progetto"
                },
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 3,
                    Data = new DateTime(2024, 1, 15, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 15, 16, 0, 0),
                    OraFine = new DateTime(2024, 1, 15, 19, 0, 0),
                    Straordinario = false,
                    Commessa = "Progetto",
                    Dettagli = "Pianificazione del progetto"
                },

                // Rendicontazione 17 Gennaio
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 4,
                    Data = new DateTime(2024, 1, 17, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 17, 9, 0, 0),
                    OraFine = new DateTime(2024, 1, 17, 13, 0, 0),
                    Straordinario = true,
                    Commessa = "Lavoro",
                    Dettagli = "Lavoro"
                },
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 4,
                    Data = new DateTime(2024, 1, 17, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 17, 14, 0, 0),
                    OraFine = new DateTime(2024, 1, 17, 18, 0, 0),
                    Straordinario = true,
                    Commessa = "Lavoro",
                    Dettagli = "Lavoro"
                },
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 1,
                    Data = new DateTime(2024, 1, 17, 22, 0, 0),
                    OraInizio = new DateTime(2024, 1, 17, 22, 0, 0),
                    OraFine = new DateTime(2024, 1, 17, 23, 0, 0),
                    Straordinario = true,
                    Commessa = "Lavoro",
                    Dettagli = "Lavoro"
                },

                // Rendicontazione prova 26 Gennaio
                new Rendicontazione
                {
                    Id= Guid.NewGuid(),
                    OreTotali = 2,
                    Data = new DateTime(2024, 1, 26, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 26, 9, 0, 0),
                    OraFine = new DateTime(2024, 1, 26, 11, 0, 0),
                    Straordinario = false,
                    Commessa = "Commessa di rendicontazione",
                    Dettagli = "Dettagli di Rendicontazioni"
                },
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 1,
                    Data = new DateTime(2024, 1, 26, 17, 0, 0),
                    OraInizio = new DateTime(2024, 1, 26, 17, 0, 0),
                    OraFine = new DateTime(2024, 1, 26, 18, 0, 0),
                    Straordinario = false,
                    Commessa = "Commessa di rendicontazione",
                    Dettagli = "Dettagli di Rendicontazioni"
                },
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 2,
                    Data = new DateTime(2024, 1, 26, 18, 0, 0),
                    OraInizio = new DateTime(2024, 1, 26, 18, 0, 0),
                    OraFine = new DateTime(2024, 1, 26, 20, 0, 0),
                    Straordinario = true,
                    Commessa = "Commessa di rendicontazione",
                    Dettagli = "Dettagli di Rendicontazioni"
                },

                // Rendicontazione 29 Gennaio
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 3,
                    Data = new DateTime(2024, 1, 29, 9, 0, 0),
                    OraInizio = new DateTime(2024, 1, 29, 9, 0, 0),
                    OraFine = new DateTime(2024, 1, 29, 12, 0, 0),
                    Straordinario = true,
                    Commessa = "Lavoro",
                    Dettagli = "Lavoro"
                },
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 3,
                    Data = new DateTime(2024, 1, 29, 19, 0, 0),
                    OraInizio = new DateTime(2024, 1, 29, 19, 0, 0),
                    OraFine = new DateTime(2024, 1, 29, 22, 0, 0),
                    Straordinario = true,
                    Commessa = "Progetto",
                    Dettagli = "Lavoro del progetto straordinario"
                },

                // Rendicontazione 5 Febbraio
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 4,
                    Data = new DateTime(2024, 2, 5, 9, 0, 0),
                    OraInizio = new DateTime(2024, 2, 5, 9, 0, 0),
                    OraFine = new DateTime(2024, 2, 5, 13, 0, 0),
                    Straordinario = false,
                    Commessa = "Aggiustamento",
                    Dettagli = "Aggiustamento ad un problema del cliente"
                },

                // Rendicontazione 6 Febbraio
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 4,
                    Data = new DateTime(2024, 2, 6, 14, 0, 0),
                    OraInizio = new DateTime(2024, 2, 6, 14, 0, 0),
                    OraFine = new DateTime(2024, 2, 6, 18, 0, 0),
                    Straordinario = false,
                    Commessa = "Progetto",
                    Dettagli = "Termine del progetto"
                },

                // Rendicontazione 7 Febbraio
                new Rendicontazione
                {
                    Id = Guid.NewGuid(),
                    OreTotali = 4,
                    Data = new DateTime(2024, 2, 7, 14, 0, 0),
                    OraInizio = new DateTime(2024, 2, 7, 14, 0, 0),
                    OraFine = new DateTime(2024, 2, 7, 18, 0, 0),
                    Straordinario = false,
                    Commessa = "Lavoro",
                    Dettagli = "Lavoro"
                }

                );

            modelBuilder.Entity<Permesso>().HasData(


                // Permesso 15 Gennaio
                new Permesso
                {
                    Id = Guid.NewGuid(),
                    Data = new DateTime(2024, 1, 15, 14, 0, 0),
                    OraInizio = new DateTime(2024, 1, 15, 14, 0, 0),
                    OraFine = new DateTime(2024, 1, 15, 16, 0, 0),
                    Durata = 120,
                    Dettagli = "Medica",
                },
                
                // Permesso prova 26 Gennaio
                new Permesso
                {
                    Id = Guid.NewGuid(),
                    Data = new DateTime(2024, 1, 26, 11, 0, 0),
                    OraInizio = new DateTime(2024, 1, 26, 11, 0, 0),
                    OraFine = new DateTime(2024, 1, 26, 13, 0, 0),
                    Durata = 180,
                    Dettagli = "Dettagli di permesso",
                },

                // Permesso 29 Gennaio
                new Permesso
                {
                    Id = Guid.NewGuid(),
                    Data = new DateTime(2024, 1, 29, 14, 0, 0),
                    OraInizio = new DateTime(2024, 1, 29, 14, 0, 0),
                    OraFine = new DateTime(2024, 1, 29, 17, 0, 0),
                    Durata = 180,
                    Dettagli = "Familiare",
                },

                // Permesso 5 Febbraio
                new Permesso
                {
                    Id = Guid.NewGuid(),
                    Data = new DateTime(2024, 2, 5, 14, 0, 0),
                    OraInizio = new DateTime(2024, 2, 5, 14, 0, 0),
                    OraFine = new DateTime(2024, 2, 5, 18, 0, 0),
                    Durata = 240,
                    Dettagli = "Malattia",
                },

                // Permesso 6 Febbraio
                new Permesso
                {
                    Id = Guid.NewGuid(),
                    Data = new DateTime(2024, 2, 6, 9, 0, 0),
                    OraInizio = new DateTime(2024, 2, 6, 9, 0, 0),
                    OraFine = new DateTime(2024, 2, 6, 13, 0, 0),
                    Durata = 180,
                    Dettagli = "Malattia",
                },

                // Permesso 7 Febbraio
                new Permesso
                {
                    Id = Guid.NewGuid(),
                    Data = new DateTime(2024, 2, 7, 9, 0, 0),
                    OraInizio = new DateTime(2024, 2, 7, 9, 0, 0),
                    OraFine = new DateTime(2024, 2, 7, 13, 0, 0),
                    Durata = 180,
                    Dettagli = "Familiare",
                }

                );
            modelBuilder.Entity<Feria>().HasData(


                // Feria dal 1 al 7 Gennaio
                new Feria
                {
                    Id = Guid.NewGuid(),
                    DataInizio = new DateTime(2024, 1, 1, 0, 0, 0),
                    DataFine = new DateTime(2024, 1, 7, 23, 59, 0),
                    Durata = 7,
                    Dettagli = "Vacanza",
                },

                // Feria dal 13 al 14 Gennaio
                new Feria
                {
                    Id = Guid.NewGuid(),
                    DataInizio = new DateTime(2024, 1, 13, 0, 0, 0),
                    DataFine = new DateTime(2024, 1, 14, 23, 59, 0),
                    Durata = 2,
                    Dettagli = "Week-end",
                },

                // Feria dal 18 al 21 Gennaio
                new Feria
                {
                    Id = Guid.NewGuid(),
                    DataInizio = new DateTime(2024, 1, 18, 0, 0, 0),
                    DataFine = new DateTime(2024, 1, 21, 23, 59, 0),
                    Durata = 4,
                    Dettagli = "Ferie",
                },
                
                // Feria prova 26 Gennaio
                new Feria
                {
                    Id = Guid.NewGuid(),
                    DataInizio = new DateTime(2024, 1, 26, 13, 0, 0),
                    DataFine = new DateTime(2024, 1, 26, 15, 0, 0),
                    Durata = 60,
                    Dettagli = "Dettagli di Ferie",
                },

                // Feria dal 1 al 4 Febbraio
                new Feria
                {
                    Id = Guid.NewGuid(),
                    DataInizio = new DateTime(2024, 2, 1, 0, 0, 0),
                    DataFine = new DateTime(2024, 2, 4, 23, 59, 0),
                    Durata = 4,
                    Dettagli = "Ferie",
                }

                );
            modelBuilder.Entity<Trasferta>().HasData(
                

                // Trasferta 16 Gennaio
                new Trasferta
                {
                    Id = Guid.NewGuid(),
                    Chilometri = 200,
                    DataInizio = new DateTime(2024, 1, 16, 6, 0, 0),
                    DataFine = new DateTime(2024, 1, 16, 22, 0, 0),
                    Commessa = "Aggiornamento",
                    AutoAziendale = false,
                    Dettagli = "Aggiornamento del sistema richiesto al cliente"
                },
                
                // Trasferta prova 26 Gennaio
                new Trasferta
                {
                    Id = Guid.NewGuid(),
                    Chilometri = 200,
                    DataInizio = new DateTime(2024, 1, 26, 15, 0, 0),
                    DataFine= new DateTime(2024, 1, 26, 17, 0, 0),
                    Commessa = "Commessa di Trasferte",
                    AutoAziendale = false,
                    Dettagli = "Dettagli di Trasferte"
                },

                // Trasferta dal 27 al 28 Gennaio
                new Trasferta
                {
                    Id = Guid.NewGuid(),
                    Chilometri = 350,
                    DataInizio = new DateTime(2024, 1, 27, 9, 0, 0),
                    DataFine = new DateTime(2024, 1, 28, 19, 0, 0),
                    Commessa = "Riparazione",
                    AutoAziendale = true,
                    Dettagli = "Riparazione ad un guasto ad un macchinario del cliente"
                }

                );
            modelBuilder.Entity<NotteFuori>().HasData(

                // Notte fuori prova 26 Gennaio
                new NotteFuori 
                {
                    Id = Guid.NewGuid(),
                    TipoViaggio = "Lavoro",
                    Data = new DateTime(2024, 1, 26, 0, 0, 0),
                    Commessa = "Commessa di notte fuori",
                    Dettagli = "Dettagli di notte fuori"
                },

                // Notte fuori dal 27 al 28
                new NotteFuori
                {
                    Id = Guid.NewGuid(),
                    TipoViaggio = "Lavoro",
                    Data = new DateTime(2024, 1, 27, 0, 0, 0),
                    Commessa = "Riparazione",
                    Dettagli = "Data la distanza tra l'azienda e cliente necessita di essere vicini per velocizzare la riparazione per il giorno dopo"
                }
                );

            modelBuilder.Entity<Rimborso>().HasData(


                // Rimborso 16 Gennaio
                new Rimborso
                {
                    Id = Guid.NewGuid(),
                    Importo = 100,
                    Data = new DateTime(2024, 1, 16, 22, 0, 0),
                    Commessa = "Commessa di rimborso",
                    CartaAziendale = false,
                    Dettagli = "Rimborso per il viaggio"
                },
                
                // Rimborso prova 26 Gennaio
                new Rimborso
                {
                    Id = Guid.NewGuid(),
                    Importo = 100,
                    Data = new DateTime(2024, 1, 26, 0, 0, 0),
                    Commessa = "Commessa di rimborso",
                    CartaAziendale = false,
                    Dettagli = "Dettagli di rimborso"
                },

                // Rimborso dal 27 al 28 Gennaio
                new Rimborso
                {
                    Id = Guid.NewGuid(),
                    Importo = 120,
                    Data = new DateTime(2024, 1, 28, 19, 0, 0),
                    Commessa = "Riparazione",
                    CartaAziendale = true,
                    Dettagli = "Rimborso per il viaggio"
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
