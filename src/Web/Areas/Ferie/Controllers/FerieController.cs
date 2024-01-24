using Core.Services.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UomoMacchina.Areas.Ferie.Data;
using UomoMacchina.Infrastructure;
using UomoMacchina.SignalR;
using static UomoMacchina.Areas.Ferie.Data.FerieViewModel;

namespace UomoMacchina.Areas.Ferie
{
    [Area ("Ferie")]
    public partial class FerieController : Controller
    {
        private readonly SharedService _sharedService;
        private readonly IPublishDomainEvents _publisher;


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
            var ferie = await _sharedService.Query(model.ToFeriaQuery());

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
            if (id.HasValue)
            {
                var model = new FerieViewModel();
                return RedirectToAction(Actions.Index(model));
            }
            else
            {
                var model = new FeriaViewModel();
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

                    Alerts.AddSuccess(this, "Ferie effetuata con successo");

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

    }
}
