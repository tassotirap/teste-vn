namespace ViajaNet.WebAccess.Domain.Core.Bus
{
    using System.Collections.Generic;
    using ViajaNet.WebAccess.Domain.Core.Events;

    public interface IEventSubscriber<T> where T : Event
    {
        void Subscribe(IEventRecived<T> eventRecived);

        void Subscribe(IEnumerable<IEventRecived<T>> eventRecived);
    }
}
