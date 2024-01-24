using Core.Services.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using UomoMacchina.SignalR;
using Core.Infrastructure.AspNetCore;
using System.Threading.Tasks;
using UomoMacchina.Areas.Main.Data;


namespace UomoMacchina.Areas.Main
{
    [Area("Main")]
    //[ApiController]
    //[Route("[controller]")]
    public partial class MainController : AuthenticatedBaseController
    {
        private readonly SharedService _sharedService;
        private readonly IPublishDomainEvents _publisher;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public MainController(SharedService sharedService, IPublishDomainEvents publisher, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _sharedService = sharedService;
            _publisher = publisher;
            _sharedLocalizer = sharedLocalizer;

            ModelUnbinderHelpers.ModelUnbinders.Add(typeof(MainViewModel), new SimplePropertyModelUnbinder());
        }

        [HttpGet]
        public async virtual Task<IActionResult> Main(MainViewModel model)
        {
            var vueCalEvents = await _sharedService.Query(model.ToVueCalEventQuery());
            model.SetVueCalEvents(vueCalEvents);
            var test = "pluto";

            return View(model);
        }
        [HttpGet]
        public async virtual Task<IActionResult> GetData(MainViewModel model)
        {
            var vueCalEvents = await _sharedService.Query(model.ToVueCalEventQuery());
            return Json(vueCalEvents.Events);
        }
    }
}
