using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Services.Shared
{
    // La classe RendicontazioneQuery serve per filtrare i dati selezionati
    public class RendicontazioneQuery
    {
        // Vedi su RendicontazioniController.cs nella Task<IActionResult> 
        public Guid Id { get; set; }
        public Guid IdCurrentUser { get; set; }
        public string Filter { get; set; }
    }

    // La classe RendicontazioniDTO serve per il data transfer object dove conta i dati 
    // da parte della classe RendicontazioneDTO
    public class RendicontazioniDTO
    {

        public RendicontazioneDTO[] Rendicontazioni { get; set; }

        public int Count { get; set; }



    }

    // La classe RendicontazioneDTO prende in riferimento parametri dal file Rendicontazioni.cs
    public class RendicontazioneDTO
    {
        public Guid Id { get; set; }

        public int OreTotali { get; set; }

        public DateTime Data { get; set; }

        public DateTime OraInizio { get; set; } 

        public DateTime OraFine { get; set; } 

        public string Commessa { get; set; }

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

        // La async Task<RendicontazioniDTO> fa una query sulla classe richiestaQuery 
        // serve ad far ridare il valore della query
        
        public async Task<RendicontazioniDTO> GetAllRendicontazioni(RendicontazioneQuery qry)
        {
            var risultato = new RendicontazioniDTO();

            IQueryable<Rendicontazione> rendicontazioni = _dbContext.Rendicontazioni;

            if (qry.Filter != null) { 
            var dataDateTime = DateTime.ParseExact(qry.Filter, "dd-MM-yyyy", null);
                //var rendicontazioni = _dbContext.Rendicontazioni.Where(x => x.Data.Date == dataDateTime);
                rendicontazioni = rendicontazioni.Where(x => x.Data.Date == dataDateTime);
            }

            //var rendicontazioni = _dbContext.Rendicontazioni.Select(x => x);

            try
            {
                risultato.Rendicontazioni = await rendicontazioni.Select(x => new RendicontazioneDTO

                {
                    Id = x.Id,
                    OreTotali = x.OreTotali,
                    Data = x.Data,
                    OraInizio = x.OraInizio,
                    OraFine = x.OraFine,
                    Commessa = x.Commessa,
                    Dettagli = x.Dettagli,
                }).ToArrayAsync();

                risultato.Count = await rendicontazioni.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }

        /* Filtro per Data */
        public async Task<RendicontazioniDTO> GetAllRendicontazioniByDate(DateTime date)
        {
            var risultato = new RendicontazioniDTO();
            var rendicontazioni = _dbContext.Rendicontazioni.Where(x => x.Data.Date == date);
            try
            {
                risultato.Rendicontazioni = await rendicontazioni.Select(x => new RendicontazioneDTO
                {
                    Id = x.Id,
                    OreTotali = x.OreTotali,
                    Data = x.Data,
                    OraInizio = x.OraInizio,
                    OraFine = x.OraFine,
                    Commessa = x.Commessa,
                    Dettagli = x.Dettagli,
                }).ToArrayAsync();

                risultato.Count = await rendicontazioni.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }

        /* Filtro per Commessa */
        public async Task<RendicontazioniDTO> GetAllByCommessa(string commessaScelta)
        {
            var risultato = new RendicontazioniDTO();
            var rendicontazioni = _dbContext.Rendicontazioni.Where(x => x.Commessa == commessaScelta);
            try
            {
                risultato.Rendicontazioni = await rendicontazioni.Select(x => new RendicontazioneDTO
                {
                    Id = x.Id,
                    OreTotali = x.OreTotali,
                    Data = x.Data,
                    OraInizio = x.OraInizio,
                    OraFine = x.OraFine,
                    Commessa = x.Commessa,
                    Dettagli = x.Dettagli,
                }).ToArrayAsync();

                risultato.Count = await rendicontazioni.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }

        /* Filtro per Dettaglio */
        public async Task<RendicontazioniDTO> GetAllRendicontazioniByDettaglio(string dettaglioScelta)
        {
            var risultato = new RendicontazioniDTO();
            var rendicontazioni = _dbContext.Rendicontazioni.Where(x => x.Dettagli.Contains(dettaglioScelta));
            try
            {
                risultato.Rendicontazioni = await rendicontazioni.Select(x => new RendicontazioneDTO
                {
                    Id = x.Id,
                    OreTotali = x.OreTotali,
                    Data = x.Data,
                    OraInizio = x.OraInizio,
                    OraFine = x.OraFine,
                    Commessa = x.Commessa,
                    Dettagli = x.Dettagli,
                }).ToArrayAsync();

                risultato.Count = await rendicontazioni.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }

        public async Task<RendicontazioneDTO> GetRendicontazioneById(RendicontazioneQuery id)
        {
            var rendicontazione = await _dbContext.Rendicontazioni
                .Where(x => x.Id == id.Id)
                .Select(x => new RendicontazioneDTO
                {
                    Id = x.Id,
                    OreTotali = x.OreTotali,
                    Data = x.Data,
                    OraFine = x.OraFine,
                    OraInizio = x.OraInizio,
                    Commessa = x.Commessa,
                    Dettagli = x.Dettagli,
                })
                .FirstOrDefaultAsync();


            return rendicontazione;
        }

        public async Task DeleteRendicontazione(Guid id)
        {
            var rendicontazione = await _dbContext.Rendicontazioni.FindAsync(id);

            if (rendicontazione != null)
            {
                _dbContext.Rendicontazioni.Remove(rendicontazione);
                await _dbContext.SaveChangesAsync();
            }
        }

    }

}
