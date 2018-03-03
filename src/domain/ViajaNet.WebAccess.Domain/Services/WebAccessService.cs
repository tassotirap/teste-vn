using ViajaNet.WebAccess.Domain.Repositories;
using ViajaNet.WebAccess.Domain.Services.Interfaces;

namespace ViajaNet.WebAccess.Domain.Services
{
    public class WebAccessService : IWebAccessService
    {
        private readonly IWebAccessRepository webAccessRepository;

        public WebAccessService(IWebAccessRepository webAccessRepository)
        {
            this.webAccessRepository = webAccessRepository;
        }

        public void Insert(Models.WebAccess webAccess)
        {
            this.webAccessRepository.Insert(webAccess);
        }
    }
}
