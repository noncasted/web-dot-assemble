namespace Global.Services.System.Updaters.Runtime.Abstract
{
    public interface IPreUpdatable
    {
        void OnPreUpdate(float delta);
    }
}