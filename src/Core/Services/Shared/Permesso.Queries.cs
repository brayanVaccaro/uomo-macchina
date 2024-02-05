using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Shared
{
    // La classe PermessoQuery serve per filtrare i dati selezionati
    public class PermessoQuery
    {
        // Vedi su PermessiController.cs nella Task<IActionResult> 
        public Guid Id { get; set; }
        public Guid IdCurrentUser { get; set; }
        public string Filter { get; set; }
    }

    // La classe PermessiDTO serve per il data transfer object dove conta i dati 
    // da parte della classe PermessoDTO
    public class PermessiDTO
    {

        //public IEnumerable<PermessoDTO> Permessi { get; set; }
        public PermessoDTO[] Permessi { get; set; }
        public int Count { get; set; }



    }

    // La classe PermessoDTO prende in riferimento parametri dal file Permessi.cs
    public class PermessoDTO
    {
        public Guid? Id { get; set; }

        public DateTime Data { get; set; }

        public DateTime OraInizio { get; set; }

        public DateTime OraFine { get; set; }

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

        // La async Task<PermessiDTO> fa una query sulla classe richiestaQuery (nella riga 10) 
        // serve ad far ridare il valore della query
        public async Task<PermessiDTO> GetAllPermessi()
        {
            var risultato = new PermessiDTO();
            var permessi = _dbContext.Permessi.Select(x => x);
            try
            {
                risultato.Permessi = await permessi.Select(x => new PermessoDTO
                {
                    Id = x.Id,
                    Data = x.Data,
                    OraInizio = x.OraInizio,
                    OraFine = x.OraFine,
                    Durata = x.OreTotali,
                    Dettagli = x.Dettagli,
                }).ToArrayAsync();

                risultato.Count = await permessi.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }
        public async Task<PermessiDTO> GetAllPermessiByDate(DateTime date)
        {
            var risultato = new PermessiDTO();
            var permessi = _dbContext.Permessi.Where(x => x.Data == date);
            try
            {
                risultato.Permessi = await permessi.Select(x => new PermessoDTO
                {
                    Id = x.Id,
                    Data = x.Data,
                    OraInizio = x.OraInizio,
                    OraFine = x.OraFine,
                    Durata = x.OreTotali,
                    Dettagli = x.Dettagli,
                }).ToArrayAsync();

                risultato.Count = await permessi.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }



        public async Task<PermessoDTO> GetPermessoById(PermessoQuery id)
        {
            var permesso = await _dbContext.Permessi
                .Where(x => x.Id == id.Id)
                .Select(x => new PermessoDTO
                {
                    Id = x.Id,
                    Data = x.Data,
                    OraInizio = x.OraInizio,
                    OraFine = x.OraFine,
                    Durata = x.OreTotali,
                    Dettagli = x.Dettagli,
                })
                .FirstOrDefaultAsync();

            
            return permesso;
        }
        public async Task DeletePermesso(Guid id)
        {
            var permesso = await _dbContext.Permessi.FindAsync(id);

            if (permesso != null)
            {
                _dbContext.Permessi.Remove(permesso);
                await _dbContext.SaveChangesAsync();
            }
        }
        
    }
}








