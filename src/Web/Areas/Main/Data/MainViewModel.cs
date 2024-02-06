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
using static UomoMacchina.Areas.Main.Data.Shared.VueCalEventsViewModel;
using static UomoMacchina.Areas.Ferie.Data.FerieViewModel;
using static UomoMacchina.Areas.Rendicontazioni.Data.RendicontazioniViewModel;
using static UomoMacchina.Areas.Permessi.Data.PermessiViewModel;
using static UomoMacchina.Areas.Trasferte.Data.TrasferteViewModel;


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

        [Display(Name = "Cerca")]
        public string Filter { get; set; }

        public AnnoViewModel Anno { get; set; }

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
        public void SetAnno(AnnoViewModel anno)
        {
            Anno = anno;
        }

        //metodo per trasformare un oggetto FeriaViewModel in un EventoDTO
        internal EventoDTO ToVueCalEvent(FeriaViewModel feria)
        {
            return new EventoDTO
            {
                StartDate = feria.DataInizio.ToString("d"),
                StartTime = feria.DataInizio.ToString("HH:mm"),
                EndDate = feria.DataFine.ToString("d"),
                EndTime = feria.DataFine.ToString("HH:mm"),
                Title = feria.Dettagli,
                Content = feria.Dettagli,
                CssClass = feria.Class,
                AllDay = false,
                Background = false,
                Deletable = true,
                Resizable = false,
            };
        }

        //metodo per trasformare un oggetto RendicontazioneViewModel in un EventoDTO
        internal EventoDTO ToVueCalEvent(RendicontazioneViewModel rendicontazione)
        {
            return new EventoDTO
            {
                StartDate = rendicontazione.Data.ToString("d"),
                StartTime = rendicontazione.OraInizio.ToString("HH:mm"),
                EndDate = rendicontazione.Data.ToString("d"),
                EndTime = rendicontazione.OraFine.ToString("HH:mm"),
                Title = rendicontazione.Dettagli,
                Content = rendicontazione.Dettagli,
                CssClass = rendicontazione.Class,
                AllDay = false,
                Background = false,
                Deletable = true,
                Resizable = false,
            };
        }

        //metodo per trasformare un oggetto PermessoViewModel in un EventoDTO
        internal EventoDTO ToVueCalEvent(PermessoViewModel permesso)
        {
            return new EventoDTO
            {
                StartDate = permesso.Data.ToString("d"),
                StartTime = permesso.OraInizio.ToString("HH:mm"),
                EndDate = permesso.Data.ToString("d"),
                EndTime = permesso.OraFine.ToString("HH:mm"),
                Title = permesso.Dettagli,
                Content = permesso.Dettagli,
                CssClass = permesso.Class,
                AllDay = false,
                Background = false,
                Deletable = true,
                Resizable = false,
            };
        }

        //metodo per trasformare un oggetto TrasfertaViewModel in un EventoDTO
        internal EventoDTO ToVueCalEvent(TrasfertaViewModel trasferta)
        {
            return new EventoDTO
            {
                StartDate = trasferta.DataInizio.ToString("d"),
                StartTime = trasferta.DataInizio.ToString("HH:mm"),
                EndDate = trasferta.DataFine.ToString("d"),
                EndTime = trasferta.DataFine.ToString("HH:mm"),
                Title = trasferta.Dettagli,
                Content = trasferta.Dettagli,
                CssClass = trasferta.Class,
                AllDay = false,
                Background = false,
                Deletable = true,
                Resizable = false,
            };
        }

        public RendicontazioneQuery ToRendicontazioneQuery()
        {
            return new RendicontazioneQuery
            {
                Filter = this.Filter
            };
        }
        public FeriaQuery ToFeriaQuery()
        {
            return new FeriaQuery
            {
                Filter = this.Filter
            };
        }

        public PermessoQuery ToPermessoQuery()
        {
            return new PermessoQuery
            {
                Filter = this.Filter
            };
        }

        public NotteFuoriQuery ToNotteFuoriQuery()
        {
            return new NotteFuoriQuery
            {
                Filter = this.Filter
            };
        }

        public TrasfertaQuery ToTrasfertaQuery()
        {
            return new TrasfertaQuery
            {
                Filter = this.Filter
            };
        }

        public RimborsoQuery ToRimborsoQuery()
        {
            return new RimborsoQuery
            {
                Filter = this.Filter
            };
        }


        public string ToJson()
        {
            return JsonSerializer.ToJsonCamelCase(this);
        }

        
    }
    public class AnnoViewModel
    {
        public List<MeseViewModel> Mesi { get; set; }

        public class MeseViewModel
        {
            public string NomeMese { get; set; }
            public List<SettimanaViewModel> Settimane { get; set; }
        }
    }

    public class SettimanaViewModel
    {
        public string Nome { get; set; }
        public List<DateTime> Giorni { get; set; }
    }
   
}
