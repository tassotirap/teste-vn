namespace ViajaNet.WebAccess.Domain.EventHandlers
{
    using System;
    using System.Threading.Tasks;
    using ViajaNet.WebAccess.Domain.Core.Bus;
    using ViajaNet.WebAccess.Domain.Events;

    public class WebAccessEventHandler : IEventSubscriber<WebAccessRegister>
    {
        public async Task ReciveEvent(WebAccessRegister @event)
        {
            Console.WriteLine(@event.WebAccess);
        }
    }
}
