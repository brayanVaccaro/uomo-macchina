
using Core.Services.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UomoMacchina.Areas.Main.Data;
using UomoMacchina.Infrastructure;

namespace UomoMacchina.Areas.NottiFuori.Data
{
    public class NottiFuoriViewModel : PagingViewModel
    {
        //costruttore
        public NottiFuoriViewModel()
        {
            OrderBy = nameof(NotteFuoriViewModel.Id);
            OrderByDescending = false;
            NottiFuori = Array.Empty<NotteFuoriViewModel>();
        }

        //parametri
        public Guid? Id { get; set; }

        [Display(Name = "Cerca")]
        public string Filtro { get; set; }


        public NotteFuoriViewModel[] NottiFuori { get; set; }


        public class NotteFuoriViewModel
        {
            public NotteFuoriViewModel() { }

            // La NotteFuoriViewModel prende i paramtri di NotteFuoriDTO quest'ultima
            // si trova su NottiFuori.Queries.cs 
            public NotteFuoriViewModel(NotteFuoriDTO notteFuoriDTO)
            {
                Id = notteFuoriDTO.Id;
                TipoViaggio = notteFuoriDTO.TipoViaggio;
                Data = notteFuoriDTO.Data;
                Commessa = notteFuoriDTO.Commessa;
                Dettagli = notteFuoriDTO.Dettagli;

            }

            public Guid? Id { get; set; }
            public string TipoViaggio { get; set; }
            public DateTime Data { get; set; }
            public string Commessa { get; set; }
            public string Dettagli { get; set; }


            public void SetNotteFuori(NotteFuoriDTO NotteFuoriDTO)
            {
                if (NotteFuoriDTO != null)
                {

                    Id = NotteFuoriDTO.Id;
                    TipoViaggio = NotteFuoriDTO.TipoViaggio;
                    Data = NotteFuoriDTO.Data;
                    Commessa = NotteFuoriDTO.Commessa;
                    Dettagli = NotteFuoriDTO.Dettagli;

                }
            }

            public AddOrUpdateNotteFuoriCommand ToAddOrUpdateNotteFuoriCommand()
            {
                return new AddOrUpdateNotteFuoriCommand
                {
                    Id = Id,
                    TipoViaggio = TipoViaggio,
                    Data = Data,
                    Commessa = Commessa,
                    Dettagli = Dettagli,
                };
            }

            public string ToJson()
            {
                return JsonSerializer.ToJsonCamelCase(this);
            }

        }

        //metodo per impostare le NottiFuori
        internal void SetNottiFuori(NottiFuoriDTO nottiFuoriDTO)
        {
            NottiFuori = nottiFuoriDTO.NottiFuori.Select(x => new NotteFuoriViewModel(x)).ToArray();

            TotalItems = nottiFuoriDTO.Count;
        }

        // Metodo per utilizzare il filtro di NotteFuoriQuery sul file NottiFuori.Queries.cs 
        


        //public override IActionResult GetRoute()
        //{
        //    throw new NotImplementedException();
        //}


        // Metodo override IActionResult di cui la rotta presa è su Startup.cs 
        public override IActionResult GetRoute() => MVC.NottiFuori.NottiFuori.Index(this).GetAwaiter().GetResult();


        public string ToJson()
        {
            return JsonSerializer.ToJsonCamelCase(this);
        }

    }
}
