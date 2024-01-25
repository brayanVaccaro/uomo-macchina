using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Shared
{
    public class AddOrUpdatePermessoCommand
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
        public async Task<Guid> Handle(AddOrUpdatePermessoCommand cmd)
        {
            var permesso = await _dbContext.Permesso
                .Where(x => x.Id == cmd.Id)
                .FirstOrDefaultAsync();

            if (permesso == null)
            {
                permesso = new Permesso
                {
                    Data = cmd.Data,
                };
                _dbContext.Permesso.Add(permesso);
            }

            permesso.Data = cmd.Data; 
            permesso.OraInizio = cmd.OraInizio;
            permesso.OraFine = cmd.OraFine;
            permesso.Durata = cmd.Durata;
            permesso.Dettagli = cmd.Dettagli;
            

            await _dbContext.SaveChangesAsync();

            return permesso.Id;
        }
    }
}