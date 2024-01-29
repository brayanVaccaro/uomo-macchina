using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Shared
{
    // La classe TrasfertaQuery serve per filtrare i dati selezionati
    public class TrasfertaQuery
    {
        // Vedi su TrasferteController.cs nella Task<IActionResult> 
        public Guid Id { get; set; }
        public Guid IdCurrentUser { get; set; }
        public string Filter { get; set; }
    }

    // La classe TrasferteDTO serve per il data transfer object dove conta i dati 
    // da parte della classe TrasfertaDTO
    public class TrasferteDTO
    {

        public TrasfertaDTO[] Trasferte { get; set; }

        public int Count { get; set; }



    }

    // La classe TrasfertaDTO prende in riferimento parametri dal file Trasferte.cs
    public class TrasfertaDTO
    {
        public Guid Id { get; set; }

        public int Chilometri { get; set; }

        public DateTime DataInizio { get; set; }

        public DateTime DataFine { get; set; }

        public string Commessa { get; set; }

        public bool AutoAziendale { get; set; }

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

        // La async Task<TrasferteDTO> fa una query sulla classe richiestaQuery 
        // serve ad far ridare il valore della query
        public async Task<TrasferteDTO> GetAllTrasferte(TrasfertaQuery qry)
        {
            var risultato = new TrasferteDTO();
            var trasferte = _dbContext.Trasferte.Select(x => x);
            try
            {
                risultato.Trasferte = await trasferte.Select(x => new TrasfertaDTO
                {
                    Id = x.Id,
                    Chilometri = x.Chilometri,
                    DataInizio = x.DataInizio,
                    DataFine = x.DataFine,
                    Commessa = x.Commessa,
                    AutoAziendale = x.AutoAziendale,
                    Dettagli = x.Dettagli,
                }).ToArrayAsync();

                risultato.Count = await trasferte.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }

        public async Task<TrasferteDTO> GetAllTrasferteByDate(DateTime date)
        {
            
            var risultato = new TrasferteDTO();
            var trasferte = _dbContext.Trasferte.Where(x => x.DataInizio == date);
            try
            {
                risultato.Trasferte = await trasferte.Select(x => new TrasfertaDTO
                {
                    Id = x.Id,
                    Chilometri = x.Chilometri,
                    DataInizio = x.DataInizio,
                    DataFine = x.DataFine,
                    Commessa = x.Commessa,
                    AutoAziendale = x.AutoAziendale,
                    Dettagli = x.Dettagli,
                }).ToArrayAsync();

                risultato.Count = await trasferte.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }
        public async Task<TrasfertaDTO> GetTrasfertaById(TrasfertaQuery id)
        {
            var trasferta = await _dbContext.Trasferte
                .Where(x => x.Id == id.Id)
                .Select(x => new TrasfertaDTO
                {
                    Id = x.Id,
                    Chilometri = x.Chilometri,
                    DataInizio = x.DataInizio,
                    DataFine = x.DataFine,
                    Commessa = x.Commessa,
                    AutoAziendale = x.AutoAziendale,
                    Dettagli = x.Dettagli,
                })
                .FirstOrDefaultAsync();


            return trasferta;
        }

        public async Task DeleteTrasferta(Guid id)
        {
            var trasferta = await _dbContext.Trasferte.FindAsync(id);

            if (trasferta != null)
            {
                _dbContext.Trasferte.Remove(trasferta);
                await _dbContext.SaveChangesAsync();
            }
        }

    }

}
