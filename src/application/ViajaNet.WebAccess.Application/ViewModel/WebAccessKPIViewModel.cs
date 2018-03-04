using System.Collections.Generic;
using ViajaNet.WebAccess.Domain.Views;

namespace ViajaNet.WebAccess.Application.ViewModel
{
    public class WebAccessKPIViewModel
    {
        public IEnumerable<BrowserKPIViewModel> BrowserKPI { get; set; }

        public IEnumerable<AccessPerHourView> AcessPerHourKPI { get; set; }
    }
}
