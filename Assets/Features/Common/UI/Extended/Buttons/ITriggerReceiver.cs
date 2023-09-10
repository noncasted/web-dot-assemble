using System;

namespace Common.UI.Extended.Buttons
{
    public interface ITriggerReceiver
    {
        event Action PointerEnter;
        event Action PointerExit;
        event Action PointerDown;
        event Action PointerUp;
    }
}