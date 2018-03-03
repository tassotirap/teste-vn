namespace ViajaNet.WebAccess.Domain.Models
{
    using System;
    using ViajaNet.WebAccess.Domain.Core.Models;

    public class WebAccess : Entity
    {
        public string Url { get; set; }

        public DateTime Data { get; set; }

        public string Location { get; set; }

        public string IP { get; set; }

        public string  Browser { get; set; }
    }
}
