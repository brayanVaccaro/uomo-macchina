using Core.Models;
using Core.Services.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using UomoMacchina.Areas.Ferie.Data;
using UomoMacchina.Areas.Main.Data.Shared;
using UomoMacchina.Areas.NottiFuori.Data;
using UomoMacchina.Areas.Permessi.Data;
using UomoMacchina.Areas.Rendicontazioni.Data;
using UomoMacchina.Areas.Rimborsi.Data;
using UomoMacchina.Areas.Trasferte.Data;
using UomoMacchina.Infrastructure;
using static UomoMacchina.Areas.Ferie.Data.FerieViewModel;
using static UomoMacchina.Areas.Main.Data.Shared.VueCalEventsViewModel;
using static UomoMacchina.Areas.Permessi.Data.PermessiViewModel;

namespace UomoMacchina.Areas.Main.Data
{

    public class MainViewModel : PagingViewModel
    {

        public MainViewModel()
        {
            Rendicontazioni = new RendicontazioniViewModel();
            Ferie = new FerieViewModel();
            Permessi = new PermessiViewModel();
            NottiFuori = new NottiFuoriViewModel();
            Trasferte = new TrasferteViewModel();
            Rimborsi = new RimborsiViewModel();
            Eventi = new VueCalEventsViewModel();
        }
        
        public SettimanaViewModel Settimana { get; set; }

        public VueCalEventsViewModel Eventi { get; set; }

        public FerieViewModel Ferie { get; set; }

        public PermessiViewModel Permessi { get; set; }

        public NottiFuoriViewModel NottiFuori { get; set; }

        public TrasferteViewModel Trasferte { get; set; }

        public RimborsiViewModel Rimborsi { get; set; }

        public RendicontazioniViewModel Rendicontazioni { get; set; }

        //public readonly PropertyInfo[] properties = typeof(MainViewModel).GetProperties();

        public override IActionResult GetRoute() => MVC.Main.Main.Main(this).GetAwaiter().GetResult();
       
        //Inizializzo le settimane
        public void SetSettimana(SettimanaViewModel settimane)
        {
            Settimana = settimane;
        }

        //metodo per trasformare un oggetto FeriaViewModel in un VueCalEventViewModel
        internal EventoDTO ToVueCalEvent(FeriaViewModel feria)
        {
            return new EventoDTO
            {
                StartDate = feria.DataInizio.ToString("d"),
                StartTime = feria.DataInizio.ToString("d"),
                EndDate = feria.DataFine.ToString("d"),
                EndTime = feria.DataFine.ToString("d"),
                Title = feria.Dettagli,
                Content = feria.Dettagli,
                CssClass = feria.Class,
                AllDay = true,
                Background = false,
                Deletable = true,
                Resizable = true,
            };
        }


        public string ToJson()
        {
            return JsonSerializer.ToJsonCamelCase(this);
        }

    }

    public class SettimanaViewModel
    {

        public List<Settimana> Settimane { get; set; }

        public class Settimana
        {
            public string Nome { get; set; }
            public List<DateTime> Giorni { get; set; } // Ogni settimana ha la sua lista di giorni
        }
    }

}
