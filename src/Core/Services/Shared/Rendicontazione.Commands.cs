using Core.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Services.Shared
{
    public class AddOrUpdateRendicontazioneCommand
    {
        public Guid? Id { get; set; }

        public int OreTotali { get; set; }

        public DateTime Data { get; set; }

        public DateTime OraInizio { get; set; } //dalle ore

        public DateTime OraFine { get; set; } // alle ore

        public string Commessa { get; set; }

        public string Dettagli { get; set; }

    }

    public partial class SharedService
    {
        public async Task<Guid> Handle(AddOrUpdateRendicontazioneCommand cmd)
        {
            var rendicontazione = await _dbContext.Rendicontazioni
                .Where(x => x.Id == cmd.Id)
                .FirstOrDefaultAsync();

            if (rendicontazione == null)
            {
                rendicontazione = new Rendicontazione
                {
                    Data = cmd.Data,
                };
                _dbContext.Rendicontazioni.Add(rendicontazione);
            }

            rendicontazione.OreTotali = cmd.OreTotali;
            rendicontazione.Data = cmd.Data;
            rendicontazione.OraInizio = cmd.OraInizio;
            rendicontazione.OraFine = cmd.OraFine;
            rendicontazione.Commessa = cmd.Commessa;
            rendicontazione.Dettagli = cmd.Dettagli;


            await _dbContext.SaveChangesAsync();

            return rendicontazione.Id;
        }
    }    
}
