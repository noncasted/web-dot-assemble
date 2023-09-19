namespace Common.UI.Extended.Buttons
{
    public class ButtonStateHandler : IButtonStateHandler
    {
        private IButtonState _current;
        
        public void Lock(IButtonState current)
        {
            _current = current;
        }

        public bool IsLocked(IButtonState state)
        {
            return state == _current;
        }
    }
}