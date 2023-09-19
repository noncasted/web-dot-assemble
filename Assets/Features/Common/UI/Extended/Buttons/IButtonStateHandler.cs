namespace Common.UI.Extended.Buttons
{
    public interface IButtonStateHandler
    {
        void Lock(IButtonState current);
        bool IsLocked(IButtonState state);
    }
}