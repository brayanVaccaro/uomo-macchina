
using Core.Services.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UomoMacchina.Areas.Permessi.Data;
using UomoMacchina.Infrastructure;
using UomoMacchina.SignalR;
using static UomoMacchina.Areas.Permessi.Data.PermessiViewModel;


namespace UomoMacchina.Areas.Permessi
{
    [Area("Permessi")]
    public partial class PermessiController : AuthenticatedBaseController
    {
        private readonly SharedService _sharedService;
        private static bool returnToIndex = false;
        private readonly IPublishDomainEvents _publisher;


        public PermessiController(SharedService sharedService)
        {
            _sharedService = sharedService;
        }

        // La Task<IActionResult> serve ad ricevere i valori sul file Index.cshtml
        // (dato dal nome stesso) e tramite il per corso di riferimento alla classe PermessiViewModel
        // nel file PermessiViewModel.cs
        [HttpGet]
        public async virtual Task<IActionResult> Index(PermessiViewModel model)
        {   // schermata index  
            var permessi = await _sharedService.GetAllPermessi();
            
            model.SetPermessi(permessi);

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

        // Costrutto della GetAllPermessi

        //secondo metodo che viene chiamato, dopo New
        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid? id, string data)
        {
            var model = new PermessoViewModel();
            if (id.HasValue)
            {
                model.SetPermesso(await _sharedService.GetPermessoById(new PermessoQuery
                {
                    Id = id.Value,
                }));
                
                return Ok(model);

            }
            else
            {
                model.SetPermesso(new PermessoDTO
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
        public virtual async Task<IActionResult> Edit(PermessoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Id = await _sharedService.Handle(model.ToAddOrUpdatePermessoCommand());
                    
                    Alerts.AddSuccess(this, "Permessi effetuata con successo");

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


        [HttpPost]
        public virtual async Task<IActionResult> SaveEdit(PermessoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Esegui l'effettivo salvataggio delle modifiche nel database
                    await _sharedService.Handle(model.ToAddOrUpdatePermessoCommand());

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
                var permesso = await _sharedService.GetPermessoById(new PermessoQuery { Id = id });

                if (permesso != null)
                {
                    // Effettua l'eliminazione della Permessi
                    await _sharedService.DeletePermesso(id);

                    Alerts.AddSuccess(this, "Permessi cancellata con successo");
                }
                else
                {
                    Alerts.AddError(this, "Permessi non trovata");
                }
            }
            catch (Exception ex)
            {
                Alerts.AddError(this, $"Errore durante l'eliminazione della Permessi: {ex.Message}");
            }

            return RedirectToAction(Actions.Index());
        }


    }

}
