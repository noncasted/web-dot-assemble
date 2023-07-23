namespace Common.Architecture.Local.Services.Abstract.EventLoops
{
    public interface ILocalDisableListener : IEventBase
    {
        void OnDisabled();
    }
}