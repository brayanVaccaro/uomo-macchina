using Core.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Shared
{
    public class AddOrUpdateNotteFuoriCommand
    {
        public Guid? Id { get; set; }

        public string TipoViaggio { get; set; }

        public DateTime Data { get; set; }

        public string Commessa { get; set; }

        public string Dettagli { get; set; }

    }

    public partial class SharedService
    {
        public async Task<Guid> Handle(AddOrUpdateNotteFuoriCommand cmd)
        {
            var notteFuori = await _dbContext.NotteFuori
                .Where(x => x.Id == cmd.Id)
                .FirstOrDefaultAsync();

            if (notteFuori == null)
            {
                notteFuori = new NotteFuori
                {
                    Data = cmd.Data,
                };
                _dbContext.NotteFuori.Add(notteFuori);
            }

            notteFuori.TipoViaggio = cmd.TipoViaggio;
            notteFuori.Data = cmd.Data;
            notteFuori.Commessa = cmd.Commessa;
            notteFuori.Dettagli = cmd.Dettagli;


            await _dbContext.SaveChangesAsync();

            return notteFuori.Id;
        }
    }
}
