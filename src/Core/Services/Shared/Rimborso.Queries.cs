using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Shared
{
    // La classe RimborsoQuery serve per filtrare i dati selezionati
    public class RimborsoQuery
    {
        // Vedi su RimborsiController.cs nella Task<IActionResult> 
        public Guid Id { get; set; }
        public Guid IdCurrentUser { get; set; }
        public string Filter { get; set; }
    }

    // La classe RimborsiDTO serve per il data transfer object dove conta i dati 
    // da parte della classe RimborsoDTO
    public class RimborsiDTO
    {

        public RimborsoDTO[] Rimborsi { get; set; }

        public int Count { get; set; }



    }

    // La classe RimborsoDTO prende in riferimento parametri dal file Rimborsi.cs
    public class RimborsoDTO
    {
        public Guid Id { get; set; }

        public int Importo { get; set; }

        public DateTime Data { get; set; }

        public string Commessa { get; set; }

        public bool CartaAziendale { get; set; }

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

        // La async Task<RimborsiDTO> fa una query sulla classe richiestaQuery 
        // serve ad far ridare il valore della query
        public async Task<RimborsiDTO> GetAllRimborsi(RimborsoQuery qry)
        {
            var risultato = new RimborsiDTO();
            var rimborsi = _dbContext.Rimborsi.Select(x => x);
            try
            {
                risultato.Rimborsi = await rimborsi.Select(x => new RimborsoDTO
                {
                    Id = x.Id,
                    Importo = x.Importo,
                    Data = x.Data,
                    Commessa = x.Commessa,
                    CartaAziendale = x.CartaAziendale,
                    Dettagli = x.Dettagli,
                }).ToArrayAsync();

                risultato.Count = await rimborsi.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }

        /* Filtro per Data */
        public async Task<RimborsiDTO> GetAllRimborsiByDate(DateTime date)
        {
            var risultato = new RimborsiDTO();
            var rimborsi = _dbContext.Rimborsi.Where(x => x.Data == date);
            try
            {
                risultato.Rimborsi = await rimborsi.Select(x => new RimborsoDTO
                {
                    Id = x.Id,
                    Importo = x.Importo,
                    Data = x.Data,
                    Commessa = x.Commessa,
                    CartaAziendale = x.CartaAziendale,
                    Dettagli = x.Dettagli,
                }).ToArrayAsync();

                risultato.Count = await rimborsi.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }

        /* Filtro per Commessa */
        public async Task<RimborsiDTO> GetAllRimborsiByCommessa(string commessaScelta)
        {
            var risultato = new RimborsiDTO();
            var rimborsi = _dbContext.Rimborsi.Where(y => y.Commessa == commessaScelta);
            try
            {
                risultato.Rimborsi = await rimborsi.Select(x => new RimborsoDTO
                {
                    Id = x.Id,
                    Importo = x.Importo,
                    Data = x.Data,
                    Commessa = x.Commessa,
                    CartaAziendale = x.CartaAziendale,
                    Dettagli = x.Dettagli,
                }).ToArrayAsync();

                risultato.Count = await rimborsi.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }


        /* Filtro per Dettaglio */
        public async Task<RimborsiDTO> GetAllRimborsiByDettaglio(string dettaglioScelta)
        {
            var risultato = new RimborsiDTO();
            var rimborsi = _dbContext.Rimborsi.Where(x => x.Dettagli.Contains(dettaglioScelta));
            try
            {
                risultato.Rimborsi = await rimborsi.Select(x => new RimborsoDTO
                {
                    Id = x.Id,
                    Importo = x.Importo,
                    Data = x.Data,
                    Commessa = x.Commessa,
                    CartaAziendale = x.CartaAziendale,
                    Dettagli = x.Dettagli,
                }).ToArrayAsync();

                risultato.Count = await rimborsi.CountAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return risultato;
        }



        public async Task<RimborsoDTO> GetRimborsoById(RimborsoQuery id)
        {
            var rimborso = await _dbContext.Rimborsi
                .Where(x => x.Id == id.Id)
                .Select(x => new RimborsoDTO
                {
                    Id = x.Id,
                    Importo = x.Importo,
                    Data = x.Data,
                    Commessa = x.Commessa,
                    CartaAziendale = x.CartaAziendale,
                    Dettagli = x.Dettagli,
                })
                .FirstOrDefaultAsync();


            return rimborso;
        }

        public async Task DeleteRimborso(Guid id)
        {
            var rimborso = await _dbContext.Rimborsi.FindAsync(id);

            if (rimborso != null)
            {
                _dbContext.Rimborsi.Remove(rimborso);
                await _dbContext.SaveChangesAsync();
            }
        }

    }

}
