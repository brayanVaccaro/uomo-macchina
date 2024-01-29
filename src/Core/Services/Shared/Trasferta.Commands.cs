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

        public DateTime Data { get; set; }

        public string Commessa { get; set; }

        public string Dettagli { get; set; }

    }

    public partial class SharedService
    {
        public async Task<Guid> Handle(AddOrUpdateTrasfertaCommand cmd)
        {
            var trasferta = await _dbContext.Trasferta
                .Where(x => x.Id == cmd.Id)
                .FirstOrDefaultAsync();

            if (trasferta == null)
            {
                trasferta = new Trasferta
                {
                    Data = cmd.Data,
                };
                _dbContext.Trasferta.Add(trasferta);
            }

            trasferta.Data = cmd.Data;
            trasferta.Chilometri = cmd.Chilometri;
            trasferta.Commessa = cmd.Commessa;
            trasferta.Dettagli = cmd.Dettagli;


            await _dbContext.SaveChangesAsync();

            return trasferta.Id;
        }
    }
}
