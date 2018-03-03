﻿namespace ViajaNet.WebAccess.Domain.Core.Bus
{
    using System.Threading.Tasks;
    using ViajaNet.WebAccess.Domain.Core.Events;

    public interface IEventHandler<T> where T : Event
    {
        Task RaiseEvent(T @event);
    }
}
