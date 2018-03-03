namespace ViajaNet.WebAccess.Domain.Core.Events
{
    using System;

    public abstract class Event 
    {
        public DateTime EventDate { get; private set; }

        protected Event()
        {
            this.EventDate = DateTime.Now;
        }
    }
}
