using System;

namespace Menu.Main.UI.Runtime
{
    public readonly struct CreateRequestEvent
    {
        public CreateRequestEvent(Action<string> errorCallback)
        {
            _errorCallback = errorCallback;
        }

        private readonly Action<string> _errorCallback;

        public void OnError(string errorMessage)
        {
            _errorCallback?.Invoke(errorMessage);
        }
    }
}