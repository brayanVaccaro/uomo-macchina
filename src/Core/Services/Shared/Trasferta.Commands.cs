using Core.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Shared
{
    public class AddOrUpdateTrasfertaCommand
    {
        public Guid? Id { get; set; }

        public int Chilometri { get; set; }

        public DateTime DataInizio { get; set; }

        public DateTime DataFine { get; set; }

        public string Commessa { get; set; }

        public bool AutoAziendale { get; set; }

        public string Dettagli { get; set; }

    }

    public partial class SharedService
    {
        public async Task<Guid> Handle(AddOrUpdateTrasfertaCommand cmd)
        {
            var trasferta = await _dbContext.Trasferte
                .Where(x => x.Id == cmd.Id)
                .FirstOrDefaultAsync();

            if (trasferta == null)
            {
                trasferta = new Trasferta
                {
                    DataInizio = cmd.DataInizio,
                };
                _dbContext.Trasferte.Add(trasferta);
            }

            trasferta.DataInizio = cmd.DataInizio;
            trasferta.DataFine = cmd.DataFine;
            trasferta.Chilometri = cmd.Chilometri;
            trasferta.Commessa = cmd.Commessa;
            trasferta.AutoAziendale = cmd.AutoAziendale;
            trasferta.Dettagli = cmd.Dettagli;


            await _dbContext.SaveChangesAsync();

            return trasferta.Id;
        }
    }
}
