using Core.Models;
using Core.Services;
using Core.Services.Shared;
using System;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Infrastructure
{
    public class DataGenerator
    {
        //public static void InitializeUsers(TemplateDbContext context)
        //{
        //    if (context.Users.Any())
        //    {
        //        return;   // Data was already seeded
        //    }

        //    context.Users.AddRange(
        //        new User
        //        {
        //            Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
        //            Email = "email1@test.it",
        //            Password = "M0Cuk9OsrcS/rTLGf5SY6DUPqU2rGc1wwV2IL88GVGo=", // SHA-256 of text "Prova"
        //            FirstName = "Nome1",
        //            LastName = "Cognome1",
        //            NickName = "Nickname1"
        //        },
        //        new User
        //        {
        //            Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), // Forced to specific Guid for tests
        //            Email = "email2@test.it",
        //            Password = "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=", // SHA-256 of text "Test"
        //            FirstName = "Nome2",
        //            LastName = "Cognome2",
        //            NickName = "Nickname2"
        //        },
        //        new User
        //        {
        //            Id = Guid.Parse("bfdef48b-c7ea-4227-8333-c635af267354"), // Forced to specific Guid for tests
        //            Email = "email3@test.it",
        //            Password = "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=", // SHA-256 of text "Test"
        //            FirstName = "Nome3",
        //            LastName = "Cognome3",
        //            NickName = "Nickname3"
        //        });

        //    context.SaveChanges();
        //}

        //public static void InitializeVueCalEvent(TemplateDbContext context)
        //{
        //    if (context.Eventi.Any())
        //    {
        //        return;   // Data was already seeded
        //    }
        //    context.Eventi.AddRange(
        //        new Eventi
        //        {
        //            Id = Guid.NewGuid(), //la stringa presa online
        //            Start = new DateTime(2024, 1, 20, 9, 0, 0),
        //            End = new DateTime(2024, 1, 20, 12, 0, 0),
        //            Class = "rendicontazione"

        //        });

        //    context.SaveChanges();
        //}

        //public static void InitializeRendicontazione(TemplateDbContext context)
        //{
        //    if (context.Rendicontazioni.Any()) { return; }

        //    context.Rendicontazioni.AddRange(
        //        new Rendicontazioni
        //        {
        //            Id = Guid.NewGuid(),
        //            Ore = 7,
        //            Data = DateTime.Now,
        //            Commessa = " Matteo Verdi",
        //            Dettagli = "Dettagli di Rendicontazioni 1",
        //        },
        //        new Rendicontazioni
        //        {
        //            Id = Guid.NewGuid(),
        //            Ore = 7,
        //            Data = DateTime.Now,
        //            Commessa = " DA ELIMINARE",
        //            Dettagli = "Dettagli di Rendicontazioni 2",
        //        }
        //        );
        //    context.SaveChanges();
        //}
        //public static void InitializePermesso(TemplateDbContext context)
        //{
        //    if (context.Permessi.Any()) { return; }

        //    context.Permessi.AddRange(
        //        new Permessi
        //        {
        //            Id = Guid.NewGuid(),
        //            Data = DateTime.Now,
        //            OraInizio = DateTime.Now,
        //            OraFine = DateTime.Now,
        //            Durata = 120,
        //            Dettagli = "Dettagli di permesso",
        //        }
        //        );
        //    context.SaveChanges();
        //}

        //public static void InitializeFeria(TemplateDbContext context)
        //{
        //    if (context.Ferie.Any()) { return; }

        //    context.Ferie.AddRange(
        //        new Ferie
        //        {
        //            Id = Guid.NewGuid(),                    
        //            DataInizio = DateTime.Now,
        //            DataFine = DateTime.Now,
        //            Durata = 60,
        //            Dettagli = "Dettagli di Ferie",
        //        }
        //        );
        //    context.SaveChanges();
        //}

        //public static void InitializeNotteFuori(TemplateDbContext context)
        //{
        //    if (context.NottiFuori.Any())
        //    {
        //        return;   // Data was already seeded
        //    }
        //    context.NottiFuori.AddRange(
        //        new NottiFuori
        //        {
        //            Id = Guid.NewGuid(), //la stringa presa online
        //            TipoViaggio = "Trasferte",
        //            Data = DateTime.Now,
        //            Commessa = "Lavoro",
        //            Dettagli = "Dettagli di Notti fuori",
        //        }
        //    );

        //    context.SaveChanges();
        //}

        //public static void InitializeTrasferta(TemplateDbContext context)
        //{
        //    if (context.Trasferte.Any())
        //    {
        //        return;   // Data was already seeded
        //    }
        //    context.Trasferte.AddRange(
        //        new Trasferte
        //        {
        //            Id = Guid.NewGuid(), //la stringa presa online
        //            Chilometri = 50,
        //            Data = DateTime.Now,
        //            Commessa = "Lavoro",
        //            AutoAziendale = "Si",
        //            Dettagli = "Dettagli di Trasferte",
        //        }
        //    );

        //    context.SaveChanges();
        //}

        //public static void InitializeRimborso(TemplateDbContext context)
        //{
        //    if (context.Rimborsi.Any())
        //    {
        //        return;   // Data was already seeded
        //    }
        //    context.Rimborsi.AddRange(
        //        new Rimborsi
        //        {
        //            Id = Guid.NewGuid(), //la stringa presa online
        //            Importo = 50,
        //            Data = DateTime.Now,
        //            Commessa = "Lavoro",
        //            CartaAziendale = "Si",
        //            Dettagli = "Dettagli di Rimborsi",
        //        }
        //    );

        //    context.SaveChanges();
        //}


    }
}


