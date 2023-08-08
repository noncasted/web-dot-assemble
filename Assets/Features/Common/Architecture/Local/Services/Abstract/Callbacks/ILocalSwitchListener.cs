namespace Common.Architecture.Local.Services.Abstract.Callbacks
{
    public interface ILocalSwitchListener : ILocalDisableListener
    {
        void OnEnabled();
    }
}