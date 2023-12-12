using Microsoft.Extensions.DependencyInjection;
using Core.Services.Shared;
using UomoMacchina.SignalR;

namespace UomoMacchina
{
    public class Container
    {
        public static void RegisterTypes(IServiceCollection container)
        {
            // Registration of all the database services you have
            container.AddScoped<SharedService>();

            // Registration of SignalR events
            container.AddScoped<IPublishDomainEvents, SignalrPublishDomainEvents>();
        }
    }
}
