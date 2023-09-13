using Common.Architecture.Local.Abstract.EventLoops;

namespace Common.Architecture.Local.Abstract.Callbacks
{
    public interface ILocalLoadListener : IEventBase
    {
        void OnLoaded();
    }
}