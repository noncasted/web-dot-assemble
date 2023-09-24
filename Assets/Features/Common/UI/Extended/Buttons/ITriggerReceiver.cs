using System;

namespace Common.UI.Extended.Buttons
{
    public interface ITriggerReceiver
    {
        bool IsInside { get; }
        
        event Action PointerEnter;
        event Action PointerExit;
        event Action PointerDown;
        event Action PointerUp;

        void Lock();
        void Unlock();
    }
}