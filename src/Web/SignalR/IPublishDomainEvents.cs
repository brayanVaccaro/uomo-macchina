using System.Threading.Tasks;

namespace UomoMacchina.SignalR
{
    public interface IPublishDomainEvents
    {
        Task Publish(object evnt);
    }
}
