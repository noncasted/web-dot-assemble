using System;
using Common.Architecture.Local.Services.Abstract.Callbacks;
using Menu.Main.UI.Runtime;

namespace Menu.Loop.Runtime
{
    public class MockMenuLoop : ILocalSwitchListener
    {
        public MockMenuLoop(
            IMenuView menu)
        {
            _menu = menu;
        }

        private readonly IMenuView _menu;

        private IDisposable _transitLobbyRequestListener;
        private IDisposable _transitMenuRequestListener;
        private IDisposable _transitLevelRequestListener;
        
        public void OnEnabled()
        {
            _menu.Open();
        }

        public void OnDisabled()
        {
            _transitLobbyRequestListener?.Dispose();
            _transitMenuRequestListener?.Dispose();
            _transitLevelRequestListener?.Dispose();
        }
    }
}