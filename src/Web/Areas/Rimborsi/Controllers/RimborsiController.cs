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
using UomoMacchina.Areas.Rimborsi.Data;
using static UomoMacchina.Areas.Rimborsi.Data.RimborsiViewModel;
using Microsoft.Extensions.Options;

namespace UomoMacchina.Areas.Rimborsi.Controllers
{
    [Area("Rimborsi")]
    public partial class RimborsiController : AuthenticatedBaseController
    {
        private readonly SharedService _sharedService;
        private static bool returnToIndex = false;
        private readonly IPublishDomainEvents _publisher;


        public RimborsiController(SharedService sharedService)
        {
            _sharedService = sharedService;
        }

        // La Task<IActionResult> serve ad ricevere i valori sul file Index.cshtml
        // (dato dal nome stesso) e tramite il per corso di riferimento alla classe RimborsiViewModel
        // nel file RimborsiViewModel.cs
        [HttpGet]
        public async virtual Task<IActionResult> Index(RimborsiViewModel model)
        {   // schermata index  
            var rimborsi = await _sharedService.GetAllRimborsi(model.ToRimborsoQuery());

            model.SetRimborsi(rimborsi);

            return View(model);//mi carica il file Index nell'area richieste
        }

        // Creazione della richiesta

        //primo metodo che viene chiamato, dal pulsante Invia sotto il form
        [HttpGet]
        public virtual IActionResult New()
        {
            return RedirectToAction(Actions.Edit());
        }

        // Costrutto della GetAllRimborsi

        //secondo metodo che viene chiamato, dopo New
        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid? id)
        {
            var model = new RimborsoViewModel();
            if (id.HasValue)
            {
                model.SetRimborso(await _sharedService.GetRimborsoById(new RimborsoQuery
                {
                    Id = id.Value,
                }));
                //qua il controllo
                if (returnToIndex)
                {
                    var indexModel = new RimborsiViewModel();
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
        public virtual async Task<IActionResult> Edit(RimborsoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Id = await _sharedService.Handle(model.ToAddOrUpdateRimborsoCommand());

                    Alerts.AddSuccess(this, "Rimborso effetuata con successo");

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
                Alerts.AddError(this, "Errore nella compilazione rimborso");
            }

            return RedirectToAction(Actions.Edit(model.Id));
        }


        [HttpPost]
        public virtual async Task<IActionResult> SaveEdit(RimborsoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Esegui l'effettivo salvataggio delle modifiche nel database
                    await _sharedService.Handle(model.ToAddOrUpdateRimborsoCommand());

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
                var rimborso = await _sharedService.GetRimborsoById(new RimborsoQuery { Id = id });

                if (rimborso != null)
                {
                    // Effettua l'eliminazione della Rimborso
                    await _sharedService.DeleteRimborso(id);

                    Alerts.AddSuccess(this, "Rimborso cancellata con successo");
                }
                else
                {
                    Alerts.AddError(this, "Rimborso non trovata");
                }
            }
            catch (Exception ex)
            {
                Alerts.AddError(this, $"Errore durante l'eliminazione della Rimborso: {ex.Message}");
            }

            return RedirectToAction(Actions.Index());
        }

    }

}
