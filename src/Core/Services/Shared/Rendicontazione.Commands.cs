using Core.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Shared
{
    public class AddOrUpdateRendicontazioneCommand
    {
        public Guid? Id { get; set; }

        public int Ore { get; set; }

        public DateTime Data { get; set; }

        public string Commessa { get; set; }

        public string Dettagli { get; set; }

    }

    public partial class SharedService
    {
        public async Task<Guid> Handle(AddOrUpdateRendicontazioneCommand cmd)
        {
            var rendicontazione = await _dbContext.Rendicontazione
                .Where(x => x.Id == cmd.Id)
                .FirstOrDefaultAsync();

            if (rendicontazione == null)
            {
                rendicontazione = new Rendicontazione
                {
                    Data = cmd.Data,
                };
                _dbContext.Rendicontazione.Add(rendicontazione);
            }

            rendicontazione.Data = cmd.Data;
            rendicontazione.Ore = cmd.Ore;
            rendicontazione.Commessa = cmd.Commessa;
            rendicontazione.Dettagli = cmd.Dettagli;


            await _dbContext.SaveChangesAsync();

            return rendicontazione.Id;
        }
    }    
}
