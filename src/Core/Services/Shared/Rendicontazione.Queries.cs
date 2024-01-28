using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    // La classe RendicontazioneDTO prende in riferimento parametri dal file Rendicontazione.cs
    public class RendicontazioneDTO
    {
        public Guid Id { get; set; }

        public int Ore { get; set; }

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

        // La async Task<RendicontazioniDTO> fa una query sulla classe richiestaQuery 
        // serve ad far ridare il valore della query
        public async Task<RendicontazioniDTO> GetAllRendicontazioni(RendicontazioneQuery qry)
        {
            var risultato = new RendicontazioniDTO();
            var prova = _dbContext.Rendicontazione.Select(x => x);
            try
            {
                risultato.Rendicontazioni = await prova.Select(x => new RendicontazioneDTO
                {
                    Id = x.Id,
                    Ore = x.Ore,
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

        public async Task<RendicontazioneDTO> GetRendicontazioneById(RendicontazioneQuery id)
        {
            var prova = await _dbContext.Rendicontazione
                .Where(x => x.Id == id.Id)
                .Select(x => new RendicontazioneDTO
                {
                    Id = x.Id,
                    Ore = x.Ore,
                    Data = x.Data,
                    Commessa = x.Commessa,
                    Dettagli = x.Dettagli,
                })
                .FirstOrDefaultAsync();


            return prova;
        }

        public async Task Delete(Guid id)
        {
            var rendicontazione = await _dbContext.Rendicontazione.FindAsync(id);

            if (rendicontazione != null)
            {
                _dbContext.Rendicontazione.Remove(rendicontazione);
                await _dbContext.SaveChangesAsync();
            }
        }

    }

}
