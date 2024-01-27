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
using UomoMacchina.Areas.Rendicontazioni.Data;
using static UomoMacchina.Areas.Rendicontazioni.Data.RendicontazioniViewModel;

namespace UomoMacchina.Areas.Rendicontazioni.Controllers
{
    [Area("Rendicontazioni")]
    public partial class RendicontazioniController : AuthenticatedBaseController
    {
        private readonly SharedService _sharedService;
        //private readonly IPublishDomainEvents _publisher;


        public RendicontazioniController(SharedService sharedService)
        {
            _sharedService = sharedService;
        }

        // La Task<IActionResult> serve ad ricevere i valori sul file Index.cshtml
        // (dato dal nome stesso) e tramite il per corso di riferimento alla classe RendicontazioniViewModel
        // nel file RendicontazioniViewModel.cs
        [HttpGet]
        public async virtual Task<IActionResult> Index(RendicontazioniViewModel model)
        {   // schermata index  
            var rendicontazioni = await _sharedService.Query(model.ToRendicontazioneQuery());

            model.SetRendicontazioni(rendicontazioni);

            return View(model);//mi carica il file Index nell'area richieste
        }

        // Creazione della richiesta

        //primo metodo che viene chiamato, dal pulsante Invia sotto il form
        [HttpGet]
        public virtual IActionResult New()
        {
            return RedirectToAction(Actions.Edit());
        }

        // Costrutto della Query

        //secondo metodo che viene chiamato, dopo New
        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid? id)
        {
            if (id.HasValue)
            {
                var model = new RendicontazioniViewModel();
                return RedirectToAction(Actions.Index(model));
            }
            else
            {
                var model = new RendicontazioneViewModel();
                return View(model);
            }

        }

        // Metodo che mi mostra il pop-up di conferma della compilazione richiesta
        [HttpPost]
        public virtual async Task<IActionResult> Edit(RendicontazioneViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Id = await _sharedService.Handle(model.ToAddOrUpdateRendicontazioneCommand());

                    Alerts.AddSuccess(this, "Rendicontazione effetuata con successo");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            // Metodo che mi mostra il pop-up di effore nella compilazione richiesta
            if (ModelState.IsValid == false)
            {
                Alerts.AddError(this, "Errore nella compilazione rendicontazione");
            }

            return RedirectToAction(Actions.Edit(model.Id));
        }
        [HttpPost]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            //try
            //{
            //    var rendicontazione = await _sharedService.QueryById(new RendicontazioneQuery { Id = id });

            //    if (rendicontazione != null)
            //    {
            //        // Effettua l'eliminazione della Rendicontazione
            //        await _sharedService.Delete(id);

            //        Alerts.AddSuccess(this, "Rendicontazione cancellata con successo");
            //    }
            //    else
            //    {
            //        Alerts.AddError(this, "Rendicontazione non trovata");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Alerts.AddError(this, $"Errore durante l'eliminazione della Rendicontazione: {ex.Message}");
            //}

            return RedirectToAction(Actions.Index());
        }

    }

}
