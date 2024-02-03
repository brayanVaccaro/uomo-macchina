
using Core.Services.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UomoMacchina.Infrastructure;


namespace UomoMacchina.Areas.Permessi.Data
{

    public class PermessiViewModel : PagingViewModel
    {
        //costruttore
        public PermessiViewModel()
        {
            Permessi = Array.Empty<PermessoViewModel>();
        }
        public PermessoViewModel[] Permessi { get; set; }

        public class PermessoViewModel
        {
            public PermessoViewModel(){}

            public PermessoViewModel(PermessoDTO permessoDTO)
            {
                Id = permessoDTO.Id;
                Data = permessoDTO.Data;
                OraInizio = permessoDTO.OraInizio;
                OraFine = permessoDTO.OraFine;
                Durata = permessoDTO.Durata;
                Dettagli = permessoDTO.Dettagli;
                
            }

            public Guid? Id { get; set; }
            public DateTime Data { get; set; }
            public DateTime OraInizio { get; set; }
            public DateTime OraFine { get; set; }
            public int Durata { get; set; }
            public string Dettagli { get; set; }
            

            public void SetPermesso(PermessoDTO permessoDTO)
            {   
                if (permessoDTO!= null)
                {
                    
                    Id = permessoDTO.Id;
                    Data = permessoDTO.Data;
                    OraInizio = permessoDTO.OraInizio;
                    OraFine = permessoDTO.OraFine;
                    Durata = permessoDTO.Durata;
                    Dettagli = permessoDTO.Dettagli;
                    
                }
            }

            public AddOrUpdatePermessoCommand ToAddOrUpdatePermessoCommand()
            {
                return new AddOrUpdatePermessoCommand
                {
                    Id = Id,
                    Data = Data,
                    OraInizio = OraInizio,
                    OraFine = OraFine,
                    Durata = Durata,
                    Dettagli = Dettagli,
                };
            }
            public string ToJson()
            {
                return JsonSerializer.ToJsonCamelCase(this);
            }
        }

        //metodo per impostare i Permessi
        internal void SetPermessi(PermessiDTO permessiDTO)
        {   
            Permessi = permessiDTO.Permessi.Select(x => new PermessoViewModel(x)).ToArray();
            
            TotalItems = permessiDTO.Count;
        }

        

        public override IActionResult GetRoute() => MVC.Permessi.Permessi.Index(this).GetAwaiter().GetResult();

    }
}
