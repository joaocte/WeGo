namespace WeGo.Administration.Core.Domain.Events.Interfaces
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}