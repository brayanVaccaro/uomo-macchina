
using Core.Services.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UomoMacchina.Areas.Main.Data;
using UomoMacchina.Infrastructure;

namespace UomoMacchina.Areas.Rendicontazioni.Data
{
    public class RendicontazioniViewModel : PagingViewModel
    {
        //costruttore
        public RendicontazioniViewModel()
        {
            OrderBy = nameof(RendicontazioneViewModel.Id);
            OrderByDescending = false;
            Rendicontazioni = Array.Empty<RendicontazioneViewModel>();
        }

        //parametri
        public Guid? Id { get; set; }

        [Display(Name = "Cerca")]
        public string Filtro { get; set; }


        public RendicontazioneViewModel[] Rendicontazioni { get; set; }


        public class RendicontazioneViewModel
        {
            public RendicontazioneViewModel() { }

            // La RendicontazioneViewModel prende i paramtri di RendicontazioneDTO quest'ultima
            // si trova su Rendicontazioni.Queries.cs 
            public RendicontazioneViewModel(RendicontazioneDTO rendicontazioneDTO)
            {
                Id = rendicontazioneDTO.Id;
                OreTotali = rendicontazioneDTO.OreTotali;
                Data = rendicontazioneDTO.Data;
                OraInizio = rendicontazioneDTO.OraInizio;
                OraFine = rendicontazioneDTO.OraFine;
                Straordinario = rendicontazioneDTO.Straordinario;
                Class = rendicontazioneDTO.Class;
                Commessa = rendicontazioneDTO.Commessa;
                Dettagli = rendicontazioneDTO.Dettagli;

            }

            public Guid? Id { get; set; }
            public int OreTotali { get; set; }
            public DateTime Data { get; set; }
            public DateTime OraInizio { get; set; }
            public DateTime OraFine { get; set; }
            public string Class { get; set; }
            public string Commessa { get; set; }
            public bool Straordinario { get; set; }
            public string Dettagli { get; set; }


            public void SetRendicontazione(RendicontazioneDTO RendicontazioneDTO)
            {
                if (RendicontazioneDTO != null)
                {

                    Id = RendicontazioneDTO.Id;
                    OreTotali = RendicontazioneDTO.OreTotali;
                    Data = RendicontazioneDTO.Data;
                    OraInizio = RendicontazioneDTO.OraInizio;
                    OraFine = RendicontazioneDTO.OraFine;
                    Straordinario = RendicontazioneDTO.Straordinario;
                    Commessa = RendicontazioneDTO.Commessa;
                    Dettagli = RendicontazioneDTO.Dettagli;

                }
            }

            public AddOrUpdateRendicontazioneCommand ToAddOrUpdateRendicontazioneCommand()
            {
                return new AddOrUpdateRendicontazioneCommand
                {
                    Id = Id,
                    OreTotali = OreTotali,
                    Data = Data,
                    OraInizio = OraInizio,
                    OraFine = OraFine,
                    Straordinario = Straordinario,
                    Commessa = Commessa,
                    Dettagli = Dettagli,
                };
            }
            internal AddOrUpdateEventCommand ToVueCalEvent(RendicontazioneViewModel rendicontazione)
            {
                return new AddOrUpdateEventCommand
                {
                    Id = null,
                    StartDate = rendicontazione.Data.ToString("d"),
                    StartTime = rendicontazione.OraInizio.ToString("HH:mm"),
                    EndDate = rendicontazione.Data.ToString("d"),
                    EndTime = rendicontazione.OraFine.ToString("HH:mm"),
                    Title = rendicontazione.Dettagli,
                    Content = rendicontazione.Dettagli,
                    CssClass = "rendicontazione",
                    Background = false,
                    Split = "",
                    AllDay = false,
                    Deletable = true,
                    Resizable = false,
                    RendicontazioneId = rendicontazione.Id,
                };
            }

            public string ToJson()
            {
                return JsonSerializer.ToJsonCamelCase(this);
            }

        }

        //metodo per impostare le Rendicontazioni
        internal void SetRendicontazioni(RendicontazioniDTO rendicontazioniDTO)
        {
            Rendicontazioni = rendicontazioniDTO.Rendicontazioni.Select(x => new RendicontazioneViewModel(x)).ToArray();

            TotalItems = rendicontazioniDTO.Count;
        }

        // Metodo per utilizzare il filtro di RendicontazioneQuery sul file Rendicontazioni.Queries.cs 
        //public RendicontazioneQuery ToRendicontazioneQuery()
        //{
        //    return new RendicontazioneQuery
        //    {
        //        Filter = this.Filtro
        //    };
        //}


        //public override IActionResult GetRoute()
        //{
        //    throw new NotImplementedException();
        //}


        // Metodo override IActionResult di cui la rotta presa è su Startup.cs 
        public override IActionResult GetRoute() => MVC.Rendicontazioni.Rendicontazioni.Index(this).GetAwaiter().GetResult();


        public string ToJson()
        {
            return JsonSerializer.ToJsonCamelCase(this);
        }

    }
}
