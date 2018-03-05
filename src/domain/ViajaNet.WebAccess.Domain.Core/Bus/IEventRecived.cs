namespace ViajaNet.WebAccess.Domain.Core.Bus
{
    using System.Threading.Tasks;
    using ViajaNet.WebAccess.Domain.Core.Events;

    public interface IEventRecived<T> where T : Event
    {
        Task EventRecivedAsync(T @event);

        void EventRecived(T @event);
    }
}
