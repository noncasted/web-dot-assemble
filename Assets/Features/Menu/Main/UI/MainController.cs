using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Dots.Definitions;
using GamePlay.Loop.Modes;
using Global.GameLoops.Events;
using Global.LevelConfigurations.Runtime;
using Global.System.MessageBrokers.Runtime;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Main.UI
{
    public class MainController : IMainController, ITab, IMainInterceptor
    {
        public MainController(
            IMainView view,
            ILevelConfigurationProvider configurationProvider,
            IDotDefinitionsStorage definitionsStorage)
        {
            _view = view;
            _configurationProvider = configurationProvider;
            _definitionsStorage = definitionsStorage;
        }

        private readonly IMainView _view;
        private readonly ILevelConfigurationProvider _configurationProvider;
        private readonly IDotDefinitionsStorage _definitionsStorage;

        public RectTransform Transform => _view.Transform;

        public async UniTask Activate(CancellationToken cancellation)
        {
            _view.ModeSelection.SetMode(_configurationProvider.Mode);
            _view.Navigation.Enable();
            _view.ModeSelection.Selected += OnModeSelected;
            _view.Construct(this, _definitionsStorage);
        }

        public void Deactivate()
        {
            _view.Navigation.Disable();
            _view.ModeSelection.Selected -= OnModeSelected;
        }

        private void OnModeSelected(GameMode mode)
        {
            _configurationProvider.SetMode(mode);
        }

        public void OnPlayRequested()
        {
            Msg.Publish(new GameRequestEvent());
        }
    }
}