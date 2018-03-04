namespace ViajaNet.WebAccess.Application.Interfaces
{
    using System.Threading.Tasks;
    using ViajaNet.WebAccess.Application.ViewModel;

    public interface IWebAccessAppService
    {
        Task Register(WebAccessViewModel webAccessViewModel);

        Task<WebAccessKPIViewModel> GetKPI();
    }
}
