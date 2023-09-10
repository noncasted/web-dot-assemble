namespace Common.UI.Extended.Buttons
{
    public interface IStateHandler
    {
        void Construct(ITriggerReceiver triggerReceiver);
        void Dispose();
    }
}