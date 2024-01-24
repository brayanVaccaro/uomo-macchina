using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Shared
{
    // La classe FeriaQuery serve per filtrare i dati selezionati
    public class FeriaQuery
    {
        // Vedi su FerieController.cs nella Task<IActionResult> 
        public Guid Id { get; set; }
        public Guid IdCurrentUser { get; set; }
        public string Filter { get; set; }
    }
    // La classe FerieDTO serve per il data transfer object dove conta i dati 
    // da parte della classe FeriaDTO
    public class FerieDTO
    {

        public IEnumerable<FeriaDTO> Ferie { get; set; }

        public int Count { get; set; }



    }

    // La classe FeriaDTO prende in riferimento parametri dal file Permesso.cs
    public class FeriaDTO
    {
        public Guid Id { get; set; }

        public DateTime DataInizio { get; set; }

        public DateTime DataFine { get; set; }

        public int Durata { get; set; }

        public string Dettagli { get; set; }



    }

    public partial class SharedService
    {
        /// <summary>
        /// Returns users for a select field
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        ///

        // La async Task<FerieDTO> fa una query sulla classe richiestaQuery (nella riga 10) 
        // serve ad far ridare il valore della query
        public async Task<FerieDTO> Query(FeriaQuery qry)
        {
            var risultato = new FerieDTO();
            var prova = _dbContext.Feria.Select(x => x);
            try
            {
                risultato.Ferie = await prova.Select(x => new FeriaDTO
                {
                    Id = x.Id,
                    DataInizio = x.DataInizio,
                    DataFine = x.DataFine,
                    Durata = x.Durata,
                    Dettagli = x.Dettagli,
                }).ToArrayAsync();

                risultato.Count = await prova.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }

        public async Task<FeriaDTO> QueryById(FeriaQuery id)
        {
            var prova = await _dbContext.Feria
                .Where(x => x.Id == id.Id)
                .Select(x => new FeriaDTO
                {
                    Id = x.Id,
                    DataInizio = x.DataInizio,
                    DataFine = x.DataFine,
                    Durata = x.Durata,
                    Dettagli = x.Dettagli,
                })
                .FirstOrDefaultAsync();


            return prova;
        }
    }
}
