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
using static UomoMacchina.Areas.Main.Data.AnnoViewModel;
using static UomoMacchina.Areas.Main.Data.AnnoViewModel.MeseViewModel;

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

            RendicontazioniDTO rendicontazioni = await _sharedService.GetAllRendicontazioni(model.ToRendicontazioneQuery());
            FerieDTO ferie = await _sharedService.GetAllFerie(model.ToFeriaQuery());
            PermessiDTO permessi = await _sharedService.GetAllPermessi(model.ToPermessoQuery());
            NottiFuoriDTO nottiFuori = await _sharedService.GetAllNottiFuori(model.ToNotteFuoriQuery());
            TrasferteDTO trasferte = await _sharedService.GetAllTrasferte(model.ToTrasfertaQuery());
            RimborsiDTO rimborsi = await _sharedService.GetAllRimborsi(model.ToRimborsoQuery());

            EventiDTO eventi = await _sharedService.GetAllEvents();
            AnnoViewModel anno = CalcolaAnno(DateTime.Now);
            //SettimanaViewModel settimane = CalcolaSettimaneDelMese(DateTime.Now);

            model.Rendicontazioni.SetRendicontazioni(rendicontazioni);
            model.Ferie.SetFerie(ferie);
            model.Permessi.SetPermessi(permessi);
            model.NottiFuori.SetNottiFuori(nottiFuori);
            model.Trasferte.SetTrasferte(trasferte);
            model.Rimborsi.SetRimborsi(rimborsi);

            model.Eventi.SetEventi(eventi);
            model.SetAnno(anno);

            return View(model);
        }


        /* Action filtro per Commessa */
        [HttpGet]
        public async virtual Task<IActionResult> GetAllByCommessa(string commessaScelta, string giornoSelezionato)
        {
            if (DateTime.TryParseExact(giornoSelezionato, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
            {
                RendicontazioniDTO rendicontazioni = await _sharedService.GetAllByCommessa(commessaScelta, dateTime);
                // FerieDTO ferie = await _sharedService.GetAllFerieByCommessa(commessaScelta);
                // PermessiDTO permessi = await _sharedService.GetAllPermessiByCommessa(commessaScelta);
                NottiFuoriDTO nottiFuori = await _sharedService.GetAllNottiFuoriByCommessa(commessaScelta, dateTime);
                TrasferteDTO trasferte = await _sharedService.GetAllTrasferteByCommessa(commessaScelta, dateTime);
                RimborsiDTO rimborsi = await _sharedService.GetAllRimborsiByCommessa(commessaScelta, dateTime);


                var model = new MainViewModel();

                model.Rendicontazioni.SetRendicontazioni(rendicontazioni);
                //model.Ferie.SetFerie(ferie);
                //model.Permessi.SetPermessi(permessi);
                model.NottiFuori.SetNottiFuori(nottiFuori);
                model.Trasferte.SetTrasferte(trasferte);
                model.Rimborsi.SetRimborsi(rimborsi);


                return Json(model);
            }
            else
            {
                return RedirectToAction(Actions.Main());
            }

        }

        /* Action filtro per Dettaglio */
        [HttpGet]
        public async virtual Task<IActionResult> GetAllByDettaglio(string dettaglioScelta, string giornoSelezionato)
        {
            if (DateTime.TryParseExact(giornoSelezionato, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
            {


                RendicontazioniDTO rendicontazioni = await _sharedService.GetAllRendicontazioniByDettaglio(dettaglioScelta, dateTime);
                FerieDTO ferie = await _sharedService.GetAllFerieByDettaglio(dettaglioScelta, dateTime);
                PermessiDTO permessi = await _sharedService.GetAllPermessiByDettaglio(dettaglioScelta, dateTime);
                NottiFuoriDTO nottiFuori = await _sharedService.GetAllNottiFuoriByDettaglio(dettaglioScelta, dateTime);
                TrasferteDTO trasferte = await _sharedService.GetAllTrasferteByDettaglio(dettaglioScelta, dateTime);
                RimborsiDTO rimborsi = await _sharedService.GetAllRimborsiByDettaglio(dettaglioScelta, dateTime);


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
                return RedirectToAction(Actions.Main());
            }

        }

        [HttpGet]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            await _sharedService.Delete(id);
            return RedirectToAction(Actions.Main());
        }


        /* Action filtro per data */
        [HttpGet]
        public async virtual Task<IActionResult> GetData(string dataScelta)
        {
            if (DateTime.TryParseExact(dataScelta, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dateFilter))
            {
                RendicontazioniDTO rendicontazioni = await _sharedService.GetAllRendicontazioniByDate(dateFilter);
                EventiDTO eventi = await _sharedService.GetAllEvents();
                FerieDTO ferie = await _sharedService.GetAllFerieByDate(dateFilter);
                PermessiDTO permessi = await _sharedService.GetAllPermessiByDate(dateFilter);
                NottiFuoriDTO nottiFuori = await _sharedService.GetAllNottiFuoriByDate(dateFilter);
                TrasferteDTO trasferte = await _sharedService.GetAllTrasferteByDate(dateFilter);
                RimborsiDTO rimborsi = await _sharedService.GetAllRimborsiByDate(dateFilter);

                var model = new MainViewModel();

                model.Rendicontazioni.SetRendicontazioni(rendicontazioni);
                model.Eventi.SetEventi(eventi);
                model.Ferie.SetFerie(ferie);
                model.Permessi.SetPermessi(permessi);
                model.NottiFuori.SetNottiFuori(nottiFuori);
                model.Trasferte.SetTrasferte(trasferte);
                model.Rimborsi.SetRimborsi(rimborsi);

                return Json(model);
            }
            else
            {
                return RedirectToAction(Actions.Main());
            }
        }

        private static AnnoViewModel CalcolaAnno(DateTime data)
        {
            var annoModel = new AnnoViewModel
            {
                Mesi = new List<MeseViewModel>()
            };

            var cultura = CultureInfo.CurrentCulture;

            for (int mese = 1; mese <= 12; mese++)
            {
                var meseModel = new MeseViewModel
                {
                    NomeMese = new DateTime(data.Year, mese, 1).ToString("MMMM"),
                    Settimane = new List<SettimanaViewModel>()
                };

                var primoDelMese = new DateTime(data.Year, mese, 1);
                var ultimoDelMese = primoDelMese.AddMonths(1).AddDays(-1);

                var numeroSettimanaCorrente = cultura.Calendar.GetWeekOfYear(primoDelMese, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

                var settimanaCorrente = new SettimanaViewModel
                {
                    Nome = "Settimana " + numeroSettimanaCorrente.ToString(),
                    Giorni = new List<DateTime>()
                };
                meseModel.Settimane.Add(settimanaCorrente);

                for (DateTime giorno = primoDelMese; giorno <= ultimoDelMese; giorno = giorno.AddDays(1))
                {
                    var numeroSettimana = cultura.Calendar.GetWeekOfYear(giorno, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

                    if (numeroSettimana != numeroSettimanaCorrente)
                    {
                        numeroSettimanaCorrente = numeroSettimana;
                        settimanaCorrente = new SettimanaViewModel
                        {
                            Nome = "Settimana " + numeroSettimanaCorrente.ToString(),
                            Giorni = new List<DateTime>()
                        };
                        meseModel.Settimane.Add(settimanaCorrente);
                    }

                    var giornoString = giorno;
                    settimanaCorrente.Giorni.Add(giornoString);
                }

                annoModel.Mesi.Add(meseModel);
            }

            return annoModel;
        }

    }
}
