namespace Common.Architecture.Local.Abstract.Callbacks
{
    public interface ILocalSwitchListener : ILocalDisableListener
    {
        void OnEnabled();
    }
}