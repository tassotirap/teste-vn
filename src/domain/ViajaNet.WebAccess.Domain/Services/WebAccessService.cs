namespace ViajaNet.WebAccess.Domain.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViajaNet.WebAccess.Domain.Repositories;
    using ViajaNet.WebAccess.Domain.Services.Interfaces;
    using ViajaNet.WebAccess.Domain.Views;

    public class WebAccessService : IWebAccessService
    {
        private readonly IWebAccessRepository webAccessRepository;

        public WebAccessService(IWebAccessRepository webAccessRepository)
        {
            this.webAccessRepository = webAccessRepository;
        }

        public async Task<IEnumerable<BrowserView>> GetBrowsersKPI()
        {
            return await this.webAccessRepository.GetBrowsersKPI();
        }

        public async Task Insert(Models.WebAccess webAccess)
        {
            await this.webAccessRepository.Insert(webAccess);
        }

         
    }
}
