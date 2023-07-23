using System;

namespace Menu.Main.UI.Runtime
{
    public struct JoinRequestEvent
    {
        public JoinRequestEvent(string roomId, Action<string> errorCallback)
        {
            RoomId = roomId;
            _errorCallback = errorCallback;
        }

        public readonly string RoomId;
        private readonly Action<string> _errorCallback;

        public void OnError(string errorMessage)
        {
            _errorCallback?.Invoke(errorMessage);
        }
    }
}