namespace Common.UI.Extended.Buttons
{
    public interface IButtonUtils
    {
        ITriggerReceiver TriggerReceiver { get; }
        IButtonStateHandler StateHandler { get; }
    }
}