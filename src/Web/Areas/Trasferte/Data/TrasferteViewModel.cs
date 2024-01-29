
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
            // si trova su Trasferte.Queries.cs 
            public TrasfertaViewModel(TrasfertaDTO trasfertaDTO)
            {
                Id = trasfertaDTO.Id;
                Chilometri = trasfertaDTO.Chilometri;
                DataInizio = trasfertaDTO.DataInizio;
                DataFine = trasfertaDTO.DataFine;
                Commessa = trasfertaDTO.Commessa;
                AutoAziendale = trasfertaDTO.AutoAziendale;
                Dettagli = trasfertaDTO.Dettagli;

            }

            public Guid? Id { get; set; }
            public int Chilometri { get; set; }
            public DateTime DataInizio { get; set; }

            public DateTime DataFine { get; set; }

            public string Commessa { get; set; }

            public bool AutoAziendale { get; set; }

            public string Dettagli { get; set; }


            public void SetTrasferta(TrasfertaDTO trasfertaDTO)
            {
                if (trasfertaDTO != null)
                {

                    Id = trasfertaDTO.Id;
                    Chilometri = trasfertaDTO.Chilometri;
                    DataInizio = trasfertaDTO.DataInizio;
                    DataFine = trasfertaDTO.DataFine;
                    Commessa = trasfertaDTO.Commessa;
                    AutoAziendale = trasfertaDTO.AutoAziendale;
                    Dettagli = trasfertaDTO.Dettagli;
                }
            }

            public AddOrUpdateTrasfertaCommand ToAddOrUpdateTrasfertaCommand()
            {
                return new AddOrUpdateTrasfertaCommand
                {
                    Id = Id,
                    Chilometri = Chilometri,
                    DataInizio = DataInizio,
                    DataFine = DataFine,
                    Commessa = Commessa,
                    AutoAziendale = AutoAziendale,
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

        // Metodo per utilizzare il filtro di TrasfertaQuery sul file Trasferte.Queries.cs 
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
