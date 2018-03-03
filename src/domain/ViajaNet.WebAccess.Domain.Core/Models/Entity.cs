namespace ViajaNet.WebAccess.Domain.Core.Models
{
    using System;

    public abstract class Entity
    {
        public Guid Id { get; private set; }

        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
