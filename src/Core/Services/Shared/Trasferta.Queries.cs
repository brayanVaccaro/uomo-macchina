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

    // La classe TrasfertaDTO prende in riferimento parametri dal file Trasferta.cs
    public class TrasfertaDTO
    {
        public Guid Id { get; set; }

        public int Chilometri { get; set; }

        public DateTime Data { get; set; }

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

        // La async Task<TrasferteDTO> fa una query sulla classe richiestaQuery 
        // serve ad far ridare il valore della query
        public async Task<TrasferteDTO> GetAllTrasferte(TrasfertaQuery qry)
        {
            var risultato = new TrasferteDTO();
            var prova = _dbContext.Trasferta.Select(x => x);
            try
            {
                risultato.Trasferte = await prova.Select(x => new TrasfertaDTO
                {
                    Id = x.Id,
                    Chilometri = x.Chilometri,
                    Data = x.Data,
                    Commessa = x.Commessa,
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

        public async Task<TrasfertaDTO> GetTrasfertaById(TrasfertaQuery id)
        {
            var prova = await _dbContext.Trasferta
                .Where(x => x.Id == id.Id)
                .Select(x => new TrasfertaDTO
                {
                    Id = x.Id,
                    Chilometri = x.Chilometri,
                    Data = x.Data,
                    Commessa = x.Commessa,
                    Dettagli = x.Dettagli,
                })
                .FirstOrDefaultAsync();


            return prova;
        }

        public async Task DeleteTrasferta(Guid id)
        {
            var trasferta = await _dbContext.Trasferta.FindAsync(id);

            if (trasferta != null)
            {
                _dbContext.Trasferta.Remove(trasferta);
                await _dbContext.SaveChangesAsync();
            }
        }

    }

}
