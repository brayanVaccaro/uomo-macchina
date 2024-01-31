using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;
using Core.Services.Shared;
using UomoMacchina.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UomoMacchina.SignalR;
using UomoMacchina.SignalR.Hubs.Events;
using UomoMacchina.Areas.Trasferte.Data;
using static UomoMacchina.Areas.Trasferte.Data.TrasferteViewModel;
using Microsoft.Extensions.Options;

namespace UomoMacchina.Areas.Trasferte.Controllers
{
    [Area("Trasferte")]
    public partial class TrasferteController : AuthenticatedBaseController
    {
        private readonly SharedService _sharedService;
        private static bool returnToIndex = false;
        private readonly IPublishDomainEvents _publisher;


        public TrasferteController(SharedService sharedService)
        {
            _sharedService = sharedService;
        }

        // La Task<IActionResult> serve ad ricevere i valori sul file Index.cshtml
        // (dato dal nome stesso) e tramite il per corso di riferimento alla classe TrasferteViewModel
        // nel file TrasferteViewModel.cs
        [HttpGet]
        public async virtual Task<IActionResult> Index(TrasferteViewModel model)
        {   // schermata index  
            var trasferte = await _sharedService.GetAllTrasferte(model.ToTrasfertaQuery());

            model.SetTrasferte(trasferte);

            // Reindirizza a "Main" nell'area desiderata
            return RedirectToAction("Main", "Main", new { area = "Main" });
            //return RedirectToAction("Main");
            //return View(model);//mi carica il file Index nell'area richieste
        }

        // Creazione della richiesta

        //primo metodo che viene chiamato, dal pulsante Invia sotto il form
        [HttpGet]
        public virtual IActionResult New()
        {
            return RedirectToAction(Actions.Edit());
        }

        // Costrutto della GetAllTrasferte

        //secondo metodo che viene chiamato, dopo New
        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid? id)
        {
            var model = new TrasfertaViewModel();
            if (id.HasValue)
            {
                model.SetTrasferta(await _sharedService.GetTrasfertaById(new TrasfertaQuery
                {
                    Id = id.Value,
                }));
                //qua il controllo
                if (returnToIndex)
                {
                    var indexModel = new TrasferteViewModel();
                    returnToIndex = false;
                    return RedirectToAction(Actions.Index(indexModel));
                }
                return View(model);

            }
            else
            {
                return View(model);
            }

        }


        // Metodo che mi mostra il pop-up di conferma della compilazione richiesta
        [HttpPost]
        public virtual async Task<IActionResult> Edit(TrasfertaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Id = await _sharedService.Handle(model.ToAddOrUpdateTrasfertaCommand());

                    Alerts.AddSuccess(this, "Trasferte effetuata con successo");

                    returnToIndex = true;

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            // Metodo che mi mostra il pop-up di effore nella compilazione richiesta
            if (ModelState.IsValid == false)
            {
                Alerts.AddError(this, "Errore nella compilazione trasferta");
            }

            return RedirectToAction(Actions.Edit(model.Id));
        }


        [HttpPost]
        public virtual async Task<IActionResult> SaveEdit(TrasfertaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Esegui l'effettivo salvataggio delle modifiche nel database
                    await _sharedService.Handle(model.ToAddOrUpdateTrasfertaCommand());

                    Alerts.AddSuccess(this, "Modifiche salvate con successo");

                    return RedirectToAction(Actions.Index());
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            // Se la validazione del modello fallisce, ritorna alla vista di modifica con gli errori
            return View(model);
        }



        [HttpPost]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var trasferta = await _sharedService.GetTrasfertaById(new TrasfertaQuery { Id = id });

                if (trasferta != null)
                {
                    // Effettua l'eliminazione della Trasferte
                    await _sharedService.DeleteTrasferta(id);

                    Alerts.AddSuccess(this, "Trasferte cancellata con successo");
                }
                else
                {
                    Alerts.AddError(this, "Trasferte non trovata");
                }
            }
            catch (Exception ex)
            {
                Alerts.AddError(this, $"Errore durante l'eliminazione della Trasferte: {ex.Message}");
            }

            return RedirectToAction(Actions.Index());
        }

    }

}
