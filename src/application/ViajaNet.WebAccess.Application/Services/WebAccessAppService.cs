namespace ViajaNet.WebAccess.Application.Services
{
    using global::AutoMapper;
    using ViajaNet.WebAccess.Application.Interfaces;
    using ViajaNet.WebAccess.Application.ViewModel;
    using ViajaNet.WebAccess.Domain.Core.Bus;
    using ViajaNet.WebAccess.Domain.Events;

    public class WebAccessAppService : IWebAccessAppService
    {
        private readonly IMapper mapper;
        private readonly IEventHandler<WebAccessRegister> eventHandlerWebAccessRegister;

        public WebAccessAppService(
            IMapper mapper,
            IEventHandler<WebAccessRegister> eventHandlerWebAccessRegister)
        {
            this.mapper = mapper;
            this.eventHandlerWebAccessRegister = eventHandlerWebAccessRegister;
        }

        public void Register(WebAccessViewModel webAccessViewModel)
        {
            var eventWebAccessRegister = this.mapper.Map<WebAccessRegister>(webAccessViewModel);
            this.eventHandlerWebAccessRegister.RaiseEvent(eventWebAccessRegister);
        }
    }
}
