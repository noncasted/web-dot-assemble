namespace Global.Services.Inputs.View.Runtime
{
    public interface IInputViewRebindCallbacks
    {
        void OnBeforeRebind();
        void OnAfterRebind();
    }
}