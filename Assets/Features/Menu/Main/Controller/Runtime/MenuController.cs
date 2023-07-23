using System;
using Common.Architecture.Local.Services.Abstract.Callbacks;
using Cysharp.Threading.Tasks;
using Global.Services.System.MessageBrokers.Runtime;
using Menu.Main.UI.Runtime;

namespace Menu.Main.Controller.Runtime
{
    public class MenuController : ILocalSwitchListener
    {
        public MenuController(
            IMenuView view)
        {
            _view = view;
        }

        private readonly IMenuView _view;

        private IDisposable _createRequestListener;
        private IDisposable _joinRequestListener;
        private UniTaskCompletionSource _completion;

        public void OnEnabled()
        {
            _createRequestListener = Msg.Listen<CreateRequestEvent>(OnCreateRequested);
            _joinRequestListener = Msg.Listen<JoinRequestEvent>(OnJoinRequested);
        }

        public void OnDisabled()
        {
            _createRequestListener?.Dispose();
            _joinRequestListener?.Dispose();
        }

        private void OnCreateRequested(CreateRequestEvent request)
        {
            ProcessCreateRequest(request).Forget();
        }

        private async UniTaskVoid ProcessCreateRequest(CreateRequestEvent request)
        {
            _view.OnLoading();

            _view.CancelLoading();
        }

        private void OnJoinRequested(JoinRequestEvent request)
        {
            ProcessJoinRequest(request).Forget();
        }

        private async UniTaskVoid ProcessJoinRequest(JoinRequestEvent request)
        {
            _view.OnLoading();
        }
    }
}