namespace Common.Architecture.Local.Services.Abstract.EventLoops
{
    public interface ILocalLoadListener : IEventBase
    {
        void OnLoaded();
    }
}