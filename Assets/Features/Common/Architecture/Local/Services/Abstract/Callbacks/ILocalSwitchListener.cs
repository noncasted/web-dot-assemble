using Common.Architecture.Local.Services.Abstract.EventLoops;

namespace Common.Architecture.Local.Services.Abstract.Callbacks
{
    public interface ILocalSwitchListener : ILocalDisableListener
    {
        void OnEnabled();
    }
}