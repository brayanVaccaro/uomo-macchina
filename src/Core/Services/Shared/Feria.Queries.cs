using Core.Models;
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

        public FeriaDTO[] Ferie { get; set; }

        public int Count { get; set; }



    }

    // La classe FeriaDTO prende in riferimento parametri dal file Permessi.cs
    public class FeriaDTO
    {
        public Guid? Id { get; set; }

        public DateTime DataInizio { get; set; }

        public DateTime DataFine { get; set; }

        public String Class { get; set; }

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

        // La async Task<FerieDTO> fa una query sulla classe richiestaQuery 
        // serve ad far ridare il valore della query
        public async Task<FerieDTO> GetAllFerie(FeriaQuery qry)
        {
            var risultato = new FerieDTO();
            var ferie = _dbContext.Ferie.Select(x => x);
            try
            {
                risultato.Ferie = await ferie.Select(x => new FeriaDTO
                {
                    Id = x.Id,
                    DataInizio = x.DataInizio,
                    DataFine = x.DataFine,
                    Durata = x.Durata,
                    Dettagli = x.Dettagli,
                }).ToArrayAsync();

                risultato.Count = await ferie.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }

        /* Filtro per Data */
        public async Task<FerieDTO> GetAllFerieByDate(DateTime date)
        {
            var risultato = new FerieDTO();
            var ferie = _dbContext.Ferie.Where(x => x.DataInizio.Date == date);
            try
            {
                risultato.Ferie = await ferie.Select(x => new FeriaDTO
                {
                    Id = x.Id,
                    DataInizio = x.DataInizio,
                    DataFine = x.DataFine,
                    Durata = x.Durata,
                    Dettagli = x.Dettagli,
                }).ToArrayAsync();

                risultato.Count = await ferie.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }


        /* Filtro per Dettaglio */
        public async Task<FerieDTO> GetAllFerieByDettaglio(string dettaglioScelta, DateTime giornoSelezionato)
        {
            var risultato = new FerieDTO();
            var ferie = _dbContext.Ferie.Where(x => x.Dettagli.Contains(dettaglioScelta) && x.DataInizio.Date == giornoSelezionato.Date);

            try
            {
                risultato.Ferie = await ferie.Select(x => new FeriaDTO
                {
                    Id = x.Id,
                    DataInizio = x.DataInizio,
                    DataFine = x.DataFine,
                    Durata = x.Durata,
                    Dettagli = x.Dettagli,
                }).ToArrayAsync();

                risultato.Count = await ferie.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }

        /* Modifica della tabella */
        public async Task<FeriaDTO> GetFeriaById(FeriaQuery id)
        {
            var feria = await _dbContext.Ferie
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


            return feria;
        }

        /* Cancellazione del dato */
        public async Task DeleteFerie(Guid id)
        {
            var feria = await _dbContext.Ferie.FindAsync(id);

            if (feria != null)
            {
                _dbContext.Ferie.Remove(feria);
                await _dbContext.SaveChangesAsync();
            }
        }

        
    }
}
