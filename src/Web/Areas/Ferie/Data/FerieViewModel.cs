
using Core.Services.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UomoMacchina.Infrastructure;


namespace UomoMacchina.Areas.Ferie.Data
{

    public class FerieViewModel : PagingViewModel
    {
        //costruttore
        public FerieViewModel()
        {
            OrderBy = nameof(FeriaViewModel.Id);
            OrderByDescending = false;
            Ferie = Array.Empty<FeriaViewModel>();
        }

        //parametri
        //public Guid? Id { get; set; }

        [Display(Name = "Cerca")]
        public string Filtro { get; set; }


        public FeriaViewModel[] Ferie { get; set; }


        public class FeriaViewModel
        {
            public FeriaViewModel() { }

            // La FeriaViewModel prende i paramtri di FeriaDTO quest'ultima
            // si trova su Feria.Queries.cs rga 32
            public FeriaViewModel(FeriaDTO feriaDTO)
            {
                Id = feriaDTO.Id;
                DataInizio = feriaDTO.DataInizio;
                DataFine = feriaDTO.DataFine;
                Durata = feriaDTO.Durata;
                Dettagli = feriaDTO.Dettagli;

            }

            public Guid? Id { get; set; }
            public DateTime DataInizio { get; set; }
            public DateTime DataFine { get; set; }
            public int Durata { get; set; }
            public string Dettagli { get; set; }


            public void SetFeria(FeriaDTO feriaDTO)
            {
                if (feriaDTO != null)
                {

                    Id = feriaDTO.Id;
                    DataInizio = feriaDTO.DataInizio;
                    DataFine = feriaDTO.DataFine;
                    Durata = feriaDTO.Durata;
                    Dettagli = feriaDTO.Dettagli;

                }
            }

            public AddOrUpdateFeriaCommand ToAddOrUpdateFeriaCommand()
            {
                return new AddOrUpdateFeriaCommand
                {
                    Id = Id,
                    DataInizio = DataInizio,
                    DataFine = DataFine,
                    Durata = Durata,
                    Dettagli = Dettagli,
                };
            }
        }
            public string ToJson()
            {
                return JsonSerializer.ToJsonCamelCase(this);
            }

        //metodo per impostare le Ferie
        internal void SetFerie(FerieDTO ferieDTO)
        {
            Ferie = ferieDTO.Ferie.Select(x => new FeriaViewModel(x)).ToArray();

            TotalItems = ferieDTO.Count;
        }

        // Metodo per utilizzare il filtro di FeriaQuery sul file Feria.Queries.cs 
        public FeriaQuery ToFeriaQuery()
        {
            return new FeriaQuery
            {
                Filter = this.Filtro
            };
        }

        public override IActionResult GetRoute() => MVC.Ferie.Ferie.Index(this).GetAwaiter().GetResult();


    }
        // Metodo override IActionResult di cui la rotta presa è su Startup.cs riga 116
        //public override IActionResult GetRoute() => MVC.Ferie.Ferie.Index(this).GetAwaiter().GetResult();

}


