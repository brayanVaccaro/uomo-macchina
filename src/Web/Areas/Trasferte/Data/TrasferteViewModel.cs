
using Core.Services.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UomoMacchina.Areas.Main.Data;
using UomoMacchina.Infrastructure;

namespace UomoMacchina.Areas.Trasferte.Data
{
    public class TrasferteViewModel : PagingViewModel
    {
        //costruttore
        public TrasferteViewModel()
        {
            OrderBy = nameof(TrasfertaViewModel.Id);
            OrderByDescending = false;
            Trasferte = Array.Empty<TrasfertaViewModel>();
        }

        //parametri
        public Guid? Id { get; set; }

        [Display(Name = "Cerca")]
        public string Filtro { get; set; }


        public TrasfertaViewModel[] Trasferte { get; set; }


        public class TrasfertaViewModel
        {
            public TrasfertaViewModel() { }

            // La TrasfertaViewModel prende i paramtri di TrasfertaDTO quest'ultima
            // si trova su Trasferta.Queries.cs 
            public TrasfertaViewModel(TrasfertaDTO trasfertaDTO)
            {
                Id = trasfertaDTO.Id;
                Chilometri = trasfertaDTO.Chilometri;
                Data = trasfertaDTO.Data;
                Commessa = trasfertaDTO.Commessa;
                Dettagli = trasfertaDTO.Dettagli;

            }

            public Guid? Id { get; set; }
            public int Chilometri { get; set; }
            public DateTime Data { get; set; }
            public string Commessa { get; set; }
            public string Dettagli { get; set; }


            public void SetTrasferta(TrasfertaDTO TrasfertaDTO)
            {
                if (TrasfertaDTO != null)
                {

                    Id = TrasfertaDTO.Id;
                    Chilometri = TrasfertaDTO.Chilometri;
                    Data = TrasfertaDTO.Data;
                    Commessa = TrasfertaDTO.Commessa;
                    Dettagli = TrasfertaDTO.Dettagli;

                }
            }

            public AddOrUpdateTrasfertaCommand ToAddOrUpdateTrasfertaCommand()
            {
                return new AddOrUpdateTrasfertaCommand
                {
                    Id = Id,
                    Chilometri = Chilometri,
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

        //metodo per impostare le Trasferte
        internal void SetTrasferte(TrasferteDTO trasferteDTO)
        {
            Trasferte = trasferteDTO.Trasferte.Select(x => new TrasfertaViewModel(x)).ToArray();

            TotalItems = trasferteDTO.Count;
        }

        // Metodo per utilizzare il filtro di TrasfertaQuery sul file Trasferta.Queries.cs 
        public TrasfertaQuery ToTrasfertaQuery()
        {
            return new TrasfertaQuery
            {
                Filter = this.Filtro
            };
        }


        //public override IActionResult GetRoute()
        //{
        //    throw new NotImplementedException();
        //}


        // Metodo override IActionResult di cui la rotta presa è su Startup.cs 
        public override IActionResult GetRoute() => MVC.Trasferte.Trasferte.Index(this).GetAwaiter().GetResult();


        public string ToJson()
        {
            return JsonSerializer.ToJsonCamelCase(this);
        }

    }
}
