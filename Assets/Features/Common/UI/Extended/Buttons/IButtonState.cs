namespace Common.UI.Extended.Buttons
{
    public interface IButtonState
    {
        void Construct(IButtonUtils utils);
        void Dispose();
    }
}