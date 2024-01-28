using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Shared
{
    // La classe NotteFuoriQuery serve per filtrare i dati selezionati
    public class NotteFuoriQuery
    {
        // Vedi su NottiFuoriController.cs nella Task<IActionResult> 
        public Guid Id { get; set; }
        public Guid IdCurrentUser { get; set; }
        public string Filter { get; set; }
    }

    // La classe NottiFuoriDTO serve per il data transfer object dove conta i dati 
    // da parte della classe NotteFuoriDTO
    public class NottiFuoriDTO
    {

        public NotteFuoriDTO[] NottiFuori { get; set; }

        public int Count { get; set; }



    }

    // La classe NotteFuoriDTO prende in riferimento parametri dal file NotteFuori.cs
    public class NotteFuoriDTO
    {
        public Guid Id { get; set; }

        public string TipoViaggio { get; set; }

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

        // La async Task<NottiFuoriDTO> fa una query sulla classe richiestaQuery 
        // serve ad far ridare il valore della query
        public async Task<NottiFuoriDTO> GetAllNottiFuori(NotteFuoriQuery qry)
        {
            var risultato = new NottiFuoriDTO();
            var prova = _dbContext.NotteFuori.Select(x => x);
            try
            {
                risultato.NottiFuori = await prova.Select(x => new NotteFuoriDTO
                {
                    Id = x.Id,
                    TipoViaggio = x.TipoViaggio,
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

        public async Task<NotteFuoriDTO> GetNotteFuoriById(NotteFuoriQuery id)
        {
            var prova = await _dbContext.NotteFuori
                .Where(x => x.Id == id.Id)
                .Select(x => new NotteFuoriDTO
                {
                    Id = x.Id,
                    TipoViaggio = x.TipoViaggio,
                    Data = x.Data,
                    Commessa = x.Commessa,
                    Dettagli = x.Dettagli,
                })
                .FirstOrDefaultAsync();


            return prova;
        }

        public async Task DeleteNotteFuori(Guid id)
        {
            var notteFuori = await _dbContext.NotteFuori.FindAsync(id);

            if (notteFuori != null)
            {
                _dbContext.NotteFuori.Remove(notteFuori);
                await _dbContext.SaveChangesAsync();
            }
        }

    }

}
