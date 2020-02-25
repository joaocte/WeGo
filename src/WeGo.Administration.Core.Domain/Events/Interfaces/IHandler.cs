namespace WeGo.Administration.Core.Domain.Events.Interfaces
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}