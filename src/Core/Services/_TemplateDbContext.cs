using System;
using Core.Infrastructure;
using Core.Models;
using Core.Services.Shared;
using Microsoft.EntityFrameworkCore;

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
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 1, 29, 8, 30, 0),
                    End = new DateTime(2024, 1, 29, 12, 0, 0),
                    Title = "Prova rendicontazione",
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
                    Title = "Prova permesso",
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
                    Start = new DateTime(2024, 1, 27, 9, 0, 0),
                    End = new DateTime(2024, 1, 28, 12, 0, 0),
                    Title = "Prova trasferta",
                    Content = null,
                    Class = "trasferta",
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
                    Title = "Prova straordinario",
                    Content = null,
                    Class = "straordinario",
                    Background = false,
                    Split="",
                    AllDay=false,
                    Deletable=false,
                    Resizable=false

                },
                new VueCalEvent
                {
                    Id = Guid.NewGuid(),
                    Start = new DateTime(2024, 2, 1, 9, 0, 0),
                    End = new DateTime(2024, 2, 3, 0, 0, 0),
                    Title = "Prova feria",
                    Content = null,
                    Class = "libero",
                    Background = true,
                    Split="",
                    AllDay=true,
                    Deletable=false,
                    Resizable=false

                }
                );
            modelBuilder.Entity<Rendicontazione>().HasData(
                new Rendicontazione
                {
                    Id= Guid.NewGuid(),
                    OreTotali = 8,
                    Data = new DateTime(2024, 1, 29, 8, 30, 0),
                    OraInizio = new DateTime(2024, 1, 29, 8, 30, 0),
                    OraFine = new DateTime(2024, 1, 29, 12, 0, 0),
                    Commessa = "Commessa di rendicontazione",
                    Dettagli = "Dettagli di Rendicontazioni"
                }
                );
            modelBuilder.Entity<Trasferta>().HasData(
                new Trasferta
                {
                    Id = Guid.NewGuid(),
                    Chilometri = 200,
                    DataInizio = new DateTime(2024, 1, 27, 9, 0, 0),
                    DataFine= new DateTime(2024, 1, 28, 12, 0, 0),
                    Commessa = "Commessa di Trasferte",
                    AutoAziendale = false,
                    Dettagli = "Dettagli di Trasferte"
                }
                );
            modelBuilder.Entity<Permesso>().HasData(
                new Permesso
                {
                    Id = Guid.NewGuid(),
                    Data = new DateTime(2024, 1, 29, 14, 0, 0),
                    OraInizio = new DateTime(2024, 1, 29, 14, 0, 0),
                    OraFine = new DateTime(2024, 1, 29, 17, 0, 0),
                    OreTotali = 180,
                    Dettagli = "Dettagli di permesso",
                });
            modelBuilder.Entity<Feria>().HasData(
                new Feria
                {
                    Id = Guid.NewGuid(),
                    DataInizio = new DateTime(2024, 2, 1, 9, 0, 0),
                    DataFine = new DateTime(2024, 2, 3, 0, 0, 0),
                    Durata = 60,
                    Dettagli = "Dettagli di Ferie",
                });
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
