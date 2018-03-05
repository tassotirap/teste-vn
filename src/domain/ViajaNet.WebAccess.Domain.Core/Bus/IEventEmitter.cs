namespace ViajaNet.WebAccess.Domain.Core.Bus
{
    using System.Threading.Tasks;
    using ViajaNet.WebAccess.Domain.Core.Events;

    public interface IEventEmitter<T> where T : Event
    {
        Task EmitAsync(T @event);

        void Emit(T @event);
    }
}
