using System;
using Common.Architecture.Local.Services.Abstract.Callbacks;
using Cysharp.Threading.Tasks;
using Global.Services.System.MessageBrokers.Runtime;
using Menu.Main.Controller.Runtime;
using Menu.Main.UI.Runtime;

namespace Menu.Loop.Runtime
{
    public class MenuLoop : ILocalSwitchListener
    {
        public MenuLoop(
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
            _transitLobbyRequestListener = Msg.Listen<TransitLobbyRequestEvent>(OnTransitLobbyRequested);

            _menu.Open();
            
            Connect().Forget();
        }

        public void OnDisabled()
        {
            _transitLobbyRequestListener?.Dispose();
            _transitMenuRequestListener?.Dispose();
            _transitLevelRequestListener?.Dispose();
        }
        
        private void OnEntityCreated()
        {
        }
        
        private async UniTask Connect()
        {
            _menu.OnLoading();
            _menu.CancelLoading();
        }

        private void OnTransitLobbyRequested(TransitLobbyRequestEvent request)
        {
            _menu.Close();
        }
    }
}