using Core.Models;
using Core.Services;
using Core.Services.Shared;
using System;
using System.Linq;

namespace Core.Infrastructure
{
    public class DataGenerator
    {
        public static void InitializeUsers(TemplateDbContext context)
        {
            if (context.Users.Any())
            {
                return;   // Data was already seeded
            }

            context.Users.AddRange(
                new User
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    Email = "email1@test.it",
                    Password = "M0Cuk9OsrcS/rTLGf5SY6DUPqU2rGc1wwV2IL88GVGo=", // SHA-256 of text "Prova"
                    FirstName = "Nome1",
                    LastName = "Cognome1",
                    NickName = "Nickname1"
                },
                new User
                {
                    Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), // Forced to specific Guid for tests
                    Email = "email2@test.it",
                    Password = "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=", // SHA-256 of text "Test"
                    FirstName = "Nome2",
                    LastName = "Cognome2",
                    NickName = "Nickname2"
                },
                new User
                {
                    Id = Guid.Parse("bfdef48b-c7ea-4227-8333-c635af267354"), // Forced to specific Guid for tests
                    Email = "email3@test.it",
                    Password = "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=", // SHA-256 of text "Test"
                    FirstName = "Nome3",
                    LastName = "Cognome3",
                    NickName = "Nickname3"
                });

            context.SaveChanges();
        }

        public static void InitializeVueCalEvent(TemplateDbContext context)
        {
            if (context.VueCalEvent.Any())
            {
                return;   // Data was already seeded
            }
            context.VueCalEvent.AddRange(
                new VueCalEvent
                {
                    Id = Guid.Parse("69f71222-8ac7-4578-a32c-293d6eca2ed0"), //la stringa presa online
                    Start = new DateTime(2024, 1, 21, 12, 0, 0),
                    End = new DateTime(2024, 1, 21, 14, 0, 0)

                }
            );

            context.SaveChanges();
        }

        public static void InitializePermesso(TemplateDbContext context)
        {
            if (context.Permesso.Any()) { return; }

            context.Permesso.AddRange(
                new Permesso
                {
                    Id = Guid.NewGuid(),
                    Data = DateTime.Now,
                    OraInizio = DateTime.Now,
                    OraFine = DateTime.Now,
                    Durata = 120,
                    Dettagli = "Dettagli di permesso",
                }
                );
            context.SaveChanges();
        }

        public static void InitializeFeria(TemplateDbContext context)
        {
            if (context.Feria.Any()) { return; }

            context.Feria.AddRange(
                new Feria
                {
                    Id = Guid.NewGuid(),                    
                    DataInizio = DateTime.Now,
                    DataFine = DateTime.Now,
                    Durata = 60,
                    Dettagli = "Dettagli di Ferie",
                }
                );
            context.SaveChanges();
        }

    }
}


/*
Permesso:
Id
Data --> la giornata in cui si richiede il permesso
OraInizio
OraFine
Durata -> quante ore dura, calcolato in base a: OraInizio + OraFine
Dettagli? --> eventuali motivazione, righe di testo a spiegare il motivo della richiesta di un permesso


Feria:
Id
DataInizio
DataFine
Durata -> per quanti giorni di ferie effettuo una richiesta di ferie
Dettagli? ->  eventuali motivazione, righe di testo a spiegare il motivo della richiesta di ferie
*/