using Core.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Shared
{
    public class AddOrUpdateRimborsoCommand
    {
        public Guid? Id { get; set; }

        public int Importo { get; set; }

        public DateTime Data { get; set; }

        public string Commessa { get; set; }

        public string CartaAziendale { get; set; }

        public string Dettagli { get; set; }

    }

    public partial class SharedService
    {
        public async Task<Guid> Handle(AddOrUpdateRimborsoCommand cmd)
        {
            var rimborso = await _dbContext.Rimborso
                .Where(x => x.Id == cmd.Id)
                .FirstOrDefaultAsync();

            if (rimborso == null)
            {
                rimborso = new Rimborso
                {
                    Data = cmd.Data,
                };
                _dbContext.Rimborso.Add(rimborso);
            }

            rimborso.Importo = cmd.Importo;
            rimborso.Data = cmd.Data;
            rimborso.Commessa = cmd.Commessa;
            rimborso.CartaAziendale = cmd.CartaAziendale;
            rimborso.Dettagli = cmd.Dettagli;


            await _dbContext.SaveChangesAsync();

            return rimborso.Id;
        }
    }
}
