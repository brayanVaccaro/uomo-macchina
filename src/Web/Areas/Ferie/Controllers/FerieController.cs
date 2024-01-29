
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Core.Services.Shared;
using UomoMacchina.Infrastructure;
using UomoMacchina.SignalR;
using UomoMacchina.Areas.Ferie.Data;
using static UomoMacchina.Areas.Ferie.Data.FerieViewModel;


namespace UomoMacchina.Areas.Ferie.Controllers
{
    [Area ("Ferie")]
    public partial class FerieController : AuthenticatedBaseController
    {
        private readonly SharedService _sharedService;
        private readonly IPublishDomainEvents _publisher;
        private static bool returnToIndex = false;
        


        public FerieController(SharedService sharedService)
        {
            _sharedService = sharedService;
        }

        // La Task<IActionResult> serve ad ricevere i valori sul file Index.cshtml
        // (dato dal nome stesso) e tramite il per corso di riferimento alla classe FerieViewModel
        // nel file FerieViewModel.cs
        [HttpGet]
        public async virtual Task<IActionResult> Index(FerieViewModel model)
        {   // schermata index  
            var ferie = await _sharedService.GetAllFerie();

            model.SetFerie(ferie);

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
            var model = new FeriaViewModel();

            if (id.HasValue)
            {
                model.SetFeria(await _sharedService.GetFeriaById(new FeriaQuery
                {
                    Id = id.Value,
                }));
                //qua il controllo
                if (returnToIndex)
                {
                    var indexModel = new FerieViewModel();
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
        public virtual async Task<IActionResult> Edit(FeriaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Id = await _sharedService.Handle(model.ToAddOrUpdateFeriaCommand());
                    returnToIndex = true;
                    Alerts.AddSuccess(this, "Ferie effetuata con successo");

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
                Alerts.AddError(this, "Errore nella compilazione richiesta");
            }

            return RedirectToAction(Actions.Edit(model.Id));
        }

        [HttpPost]
        public virtual async Task<IActionResult> SaveEdit(FeriaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Esegui l'effettivo salvataggio delle modifiche nel database
                    await _sharedService.Handle(model.ToAddOrUpdateFeriaCommand());

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
                var feria = await _sharedService.GetFeriaById(new FeriaQuery { Id = id });

                if (feria != null)
                {
                    // Effettua l'eliminazione della Ferie
                    await _sharedService.DeleteFerie(id);

                    Alerts.AddSuccess(this, "Ferie cancellata con successo");
                }
                else
                {
                    Alerts.AddError(this, "Ferie non trovata");
                }
            }
            catch (Exception ex)
            {
                Alerts.AddError(this, $"Errore durante l'eliminazione della Ferie: {ex.Message}");
            }

            return RedirectToAction(Actions.Index());
        }

    }
}
