using Core.Services.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using UomoMacchina.SignalR;
using Core.Infrastructure.AspNetCore;
using System.Threading.Tasks;
using UomoMacchina.Areas.Main.Data;
using
Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NuGet.Packaging;
using UomoMacchina.Areas.Example.Users;
using static UomoMacchina.Areas.Ferie.Data.FerieViewModel;
using NuGet.Protocol;
using UomoMacchina.Areas.Ferie.Data;


namespace UomoMacchina.Areas.Main
{
    [Area("Main")]
    public partial class MainController : AuthenticatedBaseController
    {
        private readonly SharedService _sharedService;
        private readonly IPublishDomainEvents _publisher;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;


        public MainController(SharedService sharedService, IPublishDomainEvents publisher, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _sharedService = sharedService;
            _publisher = publisher;
            _sharedLocalizer = sharedLocalizer;

            ModelUnbinderHelpers.ModelUnbinders.Add(typeof(MainViewModel), new SimplePropertyModelUnbinder());
        }

        [HttpGet]
        public async virtual Task<IActionResult> Main(MainViewModel model)
        {

            RendicontazioniDTO rendicontazioni = await _sharedService.GetAllRendicontazioni(model.Rendicontazioni.ToRendicontazioneQuery());
            FerieDTO ferie = await _sharedService.GetAllFerie();
            PermessiDTO permessi = await _sharedService.GetAllPermessi();
            NottiFuoriDTO nottiFuori = await _sharedService.GetAllNottiFuori(model.NottiFuori.ToNotteFuoriQuery());
            TrasferteDTO trasferte = await _sharedService.GetAllTrasferte(model.Trasferte.ToTrasfertaQuery());
            RimborsiDTO rimborsi = await _sharedService.GetAllRimborsi(model.Rimborsi.ToRimborsoQuery());

            EventiDTO eventi = await _sharedService.GetAllEvents();
            SettimanaViewModel settimane = CalcolaSettimaneDelMese(DateTime.Now);

            model.Rendicontazioni.SetRendicontazioni(rendicontazioni);
            model.Ferie.SetFerie(ferie);
            model.Permessi.SetPermessi(permessi);
            model.NottiFuori.SetNottiFuori(nottiFuori);
            model.Trasferte.SetTrasferte(trasferte);
            model.Rimborsi.SetRimborsi(rimborsi);

            model.Eventi.SetEventi(eventi);
            model.SetSettimana(settimane);

            return View(model);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            await _sharedService.Delete(id);
            return RedirectToAction(Actions.Main());
        }

        [HttpGet]
        public async virtual Task<IActionResult> GetData(string dataScelta)
        {
            if (DateTime.TryParseExact(dataScelta, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dateFilter))
            {
                RendicontazioniDTO rendicontazioni = await _sharedService.GetAllRendicontazioniByDate(dateFilter);
                FerieDTO ferie = await _sharedService.GetAllFerieByDate(dateFilter);
                PermessiDTO permessi = await _sharedService.GetAllPermessiByDate(dateFilter);
                NottiFuoriDTO nottiFuori = await _sharedService.GetAllNottiFuoriByDate(dateFilter);
                TrasferteDTO trasferte = await _sharedService.GetAllTrasferteByDate(dateFilter);
                RimborsiDTO rimborsi = await _sharedService.GetAllRimborsiByDate(dateFilter);
                
                var model = new MainViewModel();

                model.Rendicontazioni.SetRendicontazioni(rendicontazioni);
                model.Ferie.SetFerie(ferie);
                model.Permessi.SetPermessi(permessi);
                model.NottiFuori.SetNottiFuori(nottiFuori);
                model.Trasferte.SetTrasferte(trasferte);
                model.Rimborsi.SetRimborsi(rimborsi);
                return Json(model);
            }
            else
            {
                return RedirectToAction(Actions.Main()); //da fixare
            }
        }

        private static SettimanaViewModel CalcolaSettimaneDelMese(DateTime data)
        {
            var settimaneModel = new SettimanaViewModel();
            settimaneModel.Settimane = new List<SettimanaViewModel.Settimana>();

            var cultura = CultureInfo.CurrentCulture;
            var primoDelMese = new DateTime(data.Year, data.Month, 1);
            var ultimoDelMese = primoDelMese.AddMonths(1).AddDays(-1);

            // Inizializza numeroSettimanaCorrente con il numero della settimana del primo giorno del mese
            var numeroSettimanaCorrente = cultura.Calendar.GetWeekOfYear(primoDelMese, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

            // Inizializza una nuova settimana all'inizio
            var settimanaCorrente = new SettimanaViewModel.Settimana
            {
                Nome = "Settimana " + numeroSettimanaCorrente.ToString(),
                Giorni = new List<DateTime>()
            };
            settimaneModel.Settimane.Add(settimanaCorrente);

            for (DateTime giorno = primoDelMese; giorno <= ultimoDelMese; giorno = giorno.AddDays(1))
            {
                var numeroSettimana = cultura.Calendar.GetWeekOfYear(giorno, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

                if (numeroSettimana != numeroSettimanaCorrente)
                {
                    numeroSettimanaCorrente = numeroSettimana;
                    settimanaCorrente = new SettimanaViewModel.Settimana
                    {
                        Nome = "Settimana " + numeroSettimanaCorrente.ToString(),
                        Giorni = new List<DateTime>()
                    };
                    settimaneModel.Settimane.Add(settimanaCorrente);
                }

                var giornoString = giorno;
                settimanaCorrente.Giorni.Add(giornoString);
            }

            return settimaneModel;
        }



    }
}
