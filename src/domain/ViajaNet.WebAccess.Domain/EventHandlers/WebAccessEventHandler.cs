﻿namespace ViajaNet.WebAccess.Domain.EventHandlers
{
    using System.Threading.Tasks;
    using ViajaNet.WebAccess.Domain.Core.Bus;
    using ViajaNet.WebAccess.Domain.Events;
    using ViajaNet.WebAccess.Domain.Repositories;
    using ViajaNet.WebAccess.Domain.Services.Interfaces;

    public class WebAccessEventHandler : IEventRecived<WebAccessRegister>
    {
        private readonly IWebAccessService webAccessService;

        public WebAccessEventHandler(IWebAccessService webAccessService)
        {
            this.webAccessService = webAccessService;
        }

        public void EventRecived(WebAccessRegister @event)
        {
            throw new System.NotImplementedException();
        }

        public async Task EventRecivedAsync(WebAccessRegister @event)
        {
            await this.webAccessService.Insert(@event.WebAccess);
        }
    }
}
