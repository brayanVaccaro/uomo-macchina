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
using UomoMacchina.Areas.NottiFuori.Data;
using static UomoMacchina.Areas.NottiFuori.Data.NottiFuoriViewModel;
using Microsoft.Extensions.Options;

namespace UomoMacchina.Areas.NottiFuori.Controllers
{
    [Area("NottiFuori")]
    public partial class NottiFuoriController : AuthenticatedBaseController
    {
        private readonly SharedService _sharedService;
        private static bool returnToIndex = false;
        private readonly IPublishDomainEvents _publisher;


        public NottiFuoriController(SharedService sharedService)
        {
            _sharedService = sharedService;
        }

        // La Task<IActionResult> serve ad ricevere i valori sul file Index.cshtml
        // (dato dal nome stesso) e tramite il per corso di riferimento alla classe NottiFuoriViewModel
        // nel file NottiFuoriViewModel.cs
        [HttpGet]
        public async virtual Task<IActionResult> Index(NottiFuoriViewModel model)
        {   // schermata index  
            var nottiFuori = await _sharedService.GetAllNottiFuori(model.ToNotteFuoriQuery());

            model.SetNottiFuori(nottiFuori);

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

        // Costrutto della GetAllNottiFuori

        //secondo metodo che viene chiamato, dopo New
        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid? id, string data)
        {
            var model = new NotteFuoriViewModel();
            if (id.HasValue)
            {
                model.SetNotteFuori(await _sharedService.GetNotteFuoriById(new NotteFuoriQuery
                {
                    Id = id.Value,
                }));
                
                return Ok(model);

            }
            else
            {
                model.SetNotteFuori(new NotteFuoriDTO
                {
                    Id = null,
                    Data = DateTime.Parse(data),
                });
                return Ok(model);
            }

        }


        // Metodo che mi mostra il pop-up di conferma della compilazione richiesta
        [HttpPost]
        public virtual async Task<IActionResult> Edit(NotteFuoriViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Id = await _sharedService.Handle(model.ToAddOrUpdateNotteFuoriCommand());

                    Alerts.AddSuccess(this, "NottiFuori effetuata con successo");

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
                Alerts.AddError(this, "Errore nella compilazione notteFuori");
            }

            return RedirectToAction(Actions.Edit(model.Id,""));
        }


        [HttpPost]
        public virtual async Task<IActionResult> SaveEdit(NotteFuoriViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Esegui l'effettivo salvataggio delle modifiche nel database
                    await _sharedService.Handle(model.ToAddOrUpdateNotteFuoriCommand());

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
                var notteFuori = await _sharedService.GetNotteFuoriById(new NotteFuoriQuery { Id = id });

                if (notteFuori != null)
                {
                    // Effettua l'eliminazione della NottiFuori
                    await _sharedService.DeleteNotteFuori(id);

                    Alerts.AddSuccess(this, "NottiFuori cancellata con successo");
                }
                else
                {
                    Alerts.AddError(this, "NottiFuori non trovata");
                }
            }
            catch (Exception ex)
            {
                Alerts.AddError(this, $"Errore durante l'eliminazione della NottiFuori: {ex.Message}");
            }

            return RedirectToAction(Actions.Index());
        }

    }

}
