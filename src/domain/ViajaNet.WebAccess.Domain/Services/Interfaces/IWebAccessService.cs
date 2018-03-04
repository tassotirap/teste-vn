namespace ViajaNet.WebAccess.Domain.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViajaNet.WebAccess.Domain.Views;

    public interface IWebAccessService
    {
        Task Insert(Models.WebAccess webAccess);

        Task<IEnumerable<BrowserView>> GetBrowsersKPI();

        Task<IEnumerable<AccessPerHourView>> GetAccessPerHourKPI();
    }
}
