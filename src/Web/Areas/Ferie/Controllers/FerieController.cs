
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
    [Area("Ferie")]
    public partial class FerieController : AuthenticatedBaseController
    {
        private readonly SharedService _sharedService;
        private static bool returnToIndex = false;
        private readonly IPublishDomainEvents _publisher;


        public FerieController(SharedService sharedService)
        {
            _sharedService = sharedService;
        }

        // La Task<IActionResult> serve ad ricevere i valori sul file Index.cshtml
        // (dato dal nome stesso) e tramite il per corso di riferimento alla classe FerieViewModel
        // nel file FerieViewModel.cs

        // schermata index 
        [HttpGet]
        public async virtual Task<IActionResult> Index(FerieViewModel model)
        { 
            // Reindirizza a "Main" nell'area desiderata
            return RedirectToAction("Main", "Main", new { area = "Main" });
            
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
        public virtual async Task<IActionResult> Edit(Guid? id, string data)
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
                return Ok(model);

            }
            else
            {
                model.SetFeria(new FeriaDTO
                {
                    Id = null,
                    DataInizio = DateTime.Parse(data),
                    DataFine = DateTime.Parse(data).AddDays(1),
                });
                return Ok(model);
            }

        }

        // Metodo che mi mostra il pop-up di conferma della compilazione richiesta
        [HttpPost]
        public virtual async Task<IActionResult> Edit([FromBody]FeriaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Id = await _sharedService.Handle(model.ToAddOrUpdateFeriaCommand());
                    var evento = model.ToVueCalEvent(model);//salvo nella tabella degli eventi
                    await _sharedService.Handle(evento);
                    Alerts.AddSuccess(this, "Ferie effetuata con successo");

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
                Alerts.AddError(this, "Errore nella compilazione richiesta");
            }

            return RedirectToAction(Actions.Edit(model.Id,""));
        }


        /* Metodo salva dato */
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

        /* Metodo cancellazione */
        [HttpPost]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var feria = await _sharedService.GetFeriaById(new FeriaQuery { Id = id });

                if (feria != null)
                {
                    // Effettua l'eliminazione della Feria
                    await _sharedService.DeleteEvento(id);
                    await _sharedService.DeleteFerie(id);

                    Alerts.AddSuccess(this, "Feria cancellata con successo");
                }
                else
                {
                    Alerts.AddError(this, "Feria non trovata");
                }
            }
            catch (Exception ex)
            {
                Alerts.AddError(this, $"Errore durante l'eliminazione della Feria: {ex.Message}");
            }

            return RedirectToAction(Actions.Index());
        }

    }
}
