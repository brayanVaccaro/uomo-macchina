
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using Core.Services.Shared;
using System.Linq;
using UomoMacchina.Areas.Main.Data;
using UomoMacchina.Infrastructure;

namespace UomoMacchina.Areas.Rimborsi.Data
{
    public class RimborsiViewModel : PagingViewModel
    {
        //costruttore
        public RimborsiViewModel()
        {
            OrderBy = nameof(RimborsoViewModel.Id);
            OrderByDescending = false;
            Rimborsi = Array.Empty<RimborsoViewModel>();
        }

        //parametri
        public Guid? Id { get; set; }

        [Display(Name = "Cerca")]
        public string Filtro { get; set; }


        public RimborsoViewModel[] Rimborsi { get; set; }


        public class RimborsoViewModel
        {
            public RimborsoViewModel() { }

            // La RimborsoViewModel prende i paramtri di RimborsoDTO quest'ultima
            // si trova su Rimborsi.Queries.cs 
            public RimborsoViewModel(RimborsoDTO rimborsoDTO)
            {
                Id = rimborsoDTO.Id;
                Importo = rimborsoDTO.Importo;
                Data = rimborsoDTO.Data;
                Commessa = rimborsoDTO.Commessa;
                CartaAziendale = rimborsoDTO.CartaAziendale;
                Dettagli = rimborsoDTO.Dettagli;

            }

            public Guid? Id { get; set; }
            public int Importo { get; set; }
            public DateTime Data { get; set; }
            public string Commessa { get; set; }
            public bool CartaAziendale { get; set; }
            public string Dettagli { get; set; }


            public void SetRimborso(RimborsoDTO RimborsoDTO)
            {
                if (RimborsoDTO != null)
                {

                    Id = RimborsoDTO.Id;
                    Importo = RimborsoDTO.Importo;
                    Data = RimborsoDTO.Data;
                    Commessa = RimborsoDTO.Commessa;
                    CartaAziendale = RimborsoDTO.CartaAziendale;
                    Dettagli = RimborsoDTO.Dettagli;

                }
            }

            public AddOrUpdateRimborsoCommand ToAddOrUpdateRimborsoCommand()
            {
                return new AddOrUpdateRimborsoCommand
                {
                    Id = Id,
                    Importo = Importo,
                    Data = Data,
                    Commessa = Commessa,
                    CartaAziendale = CartaAziendale,
                    Dettagli = Dettagli,
                };
            }

            public string ToJson()
            {
                return JsonSerializer.ToJsonCamelCase(this);
            }

        }

        //metodo per impostare le Rimborsi
        internal void SetRimborsi(RimborsiDTO rimborsiDTO)
        {
            Rimborsi = rimborsiDTO.Rimborsi.Select(x => new RimborsoViewModel(x)).ToArray();

            TotalItems = rimborsiDTO.Count;
        }

        // Metodo per utilizzare il filtro di RimborsoQuery sul file Rimborsi.Queries.cs 
        public RimborsoQuery ToRimborsoQuery()
        {
            return new RimborsoQuery
            {
                Filter = this.Filtro
            };
        }


        //public override IActionResult GetRoute()
        //{
        //    throw new NotImplementedException();
        //}


        // Metodo override IActionResult di cui la rotta presa è su Startup.cs 
        public override IActionResult GetRoute() => MVC.Rimborsi.Rimborsi.Index(this).GetAwaiter().GetResult();


        public string ToJson()
        {
            return JsonSerializer.ToJsonCamelCase(this);
        }

    }
}
