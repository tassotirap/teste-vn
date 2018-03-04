namespace ViajaNet.WebAccess.Application.Services
{
    using global::AutoMapper;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViajaNet.WebAccess.Application.Interfaces;
    using ViajaNet.WebAccess.Application.ViewModel;
    using ViajaNet.WebAccess.Domain.Core.Bus;
    using ViajaNet.WebAccess.Domain.Events;
    using ViajaNet.WebAccess.Domain.Services.Interfaces;

    public class WebAccessAppService : IWebAccessAppService
    {
        private readonly IMapper mapper;
        private readonly IWebAccessService webAccessService;
        private readonly IEventEmitter<WebAccessRegister> eventHandlerWebAccessRegister;

        public WebAccessAppService(
            IMapper mapper,
            IWebAccessService webAccessService,
            IEventEmitter<WebAccessRegister> eventHandlerWebAccessRegister)
        {
            this.mapper = mapper;
            this.webAccessService = webAccessService;
            this.eventHandlerWebAccessRegister = eventHandlerWebAccessRegister;
        }

        public async Task Register(WebAccessViewModel webAccessViewModel)
        {
            var eventWebAccessRegister = this.mapper.Map<WebAccessRegister>(webAccessViewModel);
            await this.eventHandlerWebAccessRegister.Emit(eventWebAccessRegister);
        }

        public async Task<WebAccessKPIViewModel> GetKPI()
        {
            var browserKPI = await this.webAccessService.GetBrowsersKPI();
            var browserKPIViewModel = this.mapper.Map<IEnumerable<BrowserKPIViewModel>>(browserKPI);

            var acessPerHourKPI = await this.webAccessService.GetAccessPerHourKPI();
            var accessPerHourViewModel = this.mapper.Map<IEnumerable<AccessPerHourViewModel>>(acessPerHourKPI);

            return new WebAccessKPIViewModel
            {
                BrowserKPI = browserKPIViewModel,
                AcessPerHourKPI = acessPerHourKPI
            };
        }
    }

}
