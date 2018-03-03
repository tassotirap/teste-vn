namespace ViajaNet.WebAccess.Domain.Core.Bus
{
    using System.Threading.Tasks;
    using ViajaNet.WebAccess.Domain.Core.Events;

    public interface IEventSubscriber<T> where T : Event
    {
        Task ReciveEvent(T @event);
    }
}
