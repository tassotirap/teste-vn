namespace ViajaNet.WebAccess.Domain.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViajaNet.WebAccess.Domain.Views;

    public interface IWebAccessRepository
    {
        Task Insert(Models.WebAccess webAccess);

        Task<IEnumerable<BrowserView>> GetBrowsersKPI();
    }
}
