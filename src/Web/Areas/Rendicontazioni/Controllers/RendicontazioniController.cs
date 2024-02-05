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
using Microsoft.Extensions.Options;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;



// quando creo un elemento devo ritornare direttamente alltutti i controller devono ritornare alla action Main

 
namespace UomoMacchina.Areas.Rendicontazioni.Controllers
{
    [Area("Rendicontazioni")]
    public partial class RendicontazioniController : AuthenticatedBaseController
    {
        private readonly SharedService _sharedService;
        private static bool returnToIndex = false;
        private readonly IPublishDomainEvents _publisher;


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
            var rendicontazioni = await _sharedService.GetAllRendicontazioni(model.ToRendicontazioneQuery());

            model.SetRendicontazioni(rendicontazioni);

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
            return RedirectToAction(Actions.Edit(null, ""));
        }

        // Costrutto della GetAllRendicontazioni

        //**
        // * Metodo per creare una nuova rendicontazione
        // * 
        
        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid? id, string data)
        {
            var model = new RendicontazioneViewModel();
            if (id.HasValue)
            {
                model.SetRendicontazione(await _sharedService.GetRendicontazioneById(new RendicontazioneQuery
                {
                    Id = id.Value,
                }));

                return Ok(model);

            }
            else
            {
                model.SetRendicontazione(new RendicontazioneDTO
                {
                    Id = null,
                    Data = DateTime.Parse(data),
                    OraInizio = DateTime.Parse(data),
                    OraFine = DateTime.Parse(data),
                });
                return Ok(model);
            }

        }


        // Metodo che mi mostra il pop-up di conferma della compilazione richiesta
        [HttpPost]
        public virtual async Task<IActionResult> Edit([FromBody]RendicontazioneViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Id = await _sharedService.Handle(model.ToAddOrUpdateRendicontazioneCommand());

                    Alerts.AddSuccess(this, "Rendicontazioni effetuata con successo");

                    return RedirectToAction("Main", "Main", new { area = "Main" });

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

            return RedirectToAction(Actions.Edit(model.Id, ""));
        }


        [HttpPost]
        public virtual async Task<IActionResult> SaveEdit(RendicontazioneViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Esegui l'effettivo salvataggio delle modifiche nel database
                    await _sharedService.Handle(model.ToAddOrUpdateRendicontazioneCommand());

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
                var rendicontazione = await _sharedService.GetRendicontazioneById(new RendicontazioneQuery { Id = id });

                if (rendicontazione != null)
                {
                    // Effettua l'eliminazione della Rendicontazioni
                    await _sharedService.Delete(id);

                    Alerts.AddSuccess(this, "Rendicontazioni cancellata con successo");
                }
                else
                {
                    Alerts.AddError(this, "Rendicontazioni non trovata");
                }
            }
            catch (Exception ex)
            {
                Alerts.AddError(this, $"Errore durante l'eliminazione della Rendicontazioni: {ex.Message}");
            }

            return RedirectToAction(Actions.Index());
        }

    }

}