﻿using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services.Shared
{
    public class AddOrUpdateFeriaCommand
    {
        public Guid? Id { get; set; }

        public DateTime DataInizio { get; set; }

        public DateTime DataFine { get; set; }

        public int Durata { get; set; }

        public string Dettagli { get; set; }

    }

    public partial class SharedService
    {
        public async Task<Guid> Handle(AddOrUpdateFeriaCommand cmd)
        {
            var feria = await _dbContext.Ferie
                .Where(x => x.Id == cmd.Id)
                .FirstOrDefaultAsync();

            if (feria == null)
            {
                feria = new Feria
                {
                    DataInizio = cmd.DataInizio,
                    DataFine = cmd.DataFine,
                    Durata = cmd.Durata,
                    Dettagli = cmd.Dettagli,
                };
                _dbContext.Ferie.Add(feria);
            }


            feria.DataInizio = cmd.DataInizio;
            feria.DataFine = cmd.DataFine;
            feria.Durata = cmd.Durata;
            feria.Dettagli = cmd.Dettagli;


            await _dbContext.SaveChangesAsync();

            return feria.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            // la feria da eliminare scelta sulla base dell'id di cmd
            var feria = await _dbContext.Ferie
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if(feria == null)
            {
                return false;
            }

            _dbContext.Ferie.Remove(feria);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
