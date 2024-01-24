using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;
using Core.Infrastructure.AspNetCore;
using Core.Services.Shared;
using UomoMacchina.Infrastructure;
using UomoMacchina.SignalR;
using UomoMacchina.SignalR.Hubs.Events;

namespace UomoMacchina.Areas.Example.Users
{
    [Area("Example")]
    public partial class UsersController : AuthenticatedBaseController
    {
        private readonly SharedService _sharedService;
        private readonly IPublishDomainEvents _publisher;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public UsersController(SharedService sharedService, IPublishDomainEvents publisher, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _sharedService = sharedService;
            _publisher = publisher;
            _sharedLocalizer = sharedLocalizer;

            ModelUnbinderHelpers.ModelUnbinders.Add(typeof(IndexViewModel), new SimplePropertyModelUnbinder());
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(IndexViewModel model)
        {   //schermata index s1
            var users = await _sharedService.Query(model.ToUsersIndexQuery());
            model.SetUsers(users);
            // s2
            return View(model);
        }
        // p1 crea utente 
        [HttpGet]
        public virtual IActionResult New()
        {  // s3
            return RedirectToAction(Actions.Edit());
        }
        // p3 inserimento
        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid? id)
        {
            var model = new EditViewModel();

            if (id.HasValue)
            { //p2  // s8
                model.SetUser(await _sharedService.Query(new UserDetailQuery
                {
                    Id = id.Value,
                }));
            }


            // p1 - p2  // s4 s11
            return View(model);
        }
        // p2 salva dati inseriti utente
        [HttpPost]
        public virtual async Task<IActionResult> Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Id = await _sharedService.Handle(model.ToAddOrUpdateUserCommand());
                    // s5
                    Alerts.AddSuccess(this, "Informazioni aggiornate");
                    // s6
                    // Esempio lancio di un evento SignalR
                    await _publisher.Publish(new NewMessageEvent
                    {
                        IdGroup = model.Id.Value,
                        IdUser = model.Id.Value,
                        IdMessage = Guid.NewGuid()
                    });
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            if (ModelState.IsValid == false)
            {
                Alerts.AddError(this, "Errore in aggiornamento");
            }
            // p2  // s7
            return RedirectToAction(Actions.Edit(model.Id));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            // Query to delete user

            Alerts.AddSuccess(this, "Utente cancellato");

            return RedirectToAction(Actions.Index());
        }
    }
}
