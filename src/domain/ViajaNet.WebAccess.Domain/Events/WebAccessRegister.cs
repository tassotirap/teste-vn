using ViajaNet.WebAccess.Domain.Core.Events;

namespace ViajaNet.WebAccess.Domain.Events
{
    public class WebAccessRegister : Event
    {
        public WebAccessRegister(Models.WebAccess webAccess)
        {
            WebAccess = webAccess;
        }

        public Models.WebAccess WebAccess { get; }
    }
}
