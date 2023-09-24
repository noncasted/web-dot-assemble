using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Loop.Modes;
using Global.LevelConfigurations.Runtime;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Main.UI
{
    public class MainController : IMainController, ITab
    {
        public MainController(IMainView view, ILevelConfigurationProvider configurationProvider)
        {
            _view = view;
            _configurationProvider = configurationProvider;
        }

        private readonly IMainView _view;
        private readonly ILevelConfigurationProvider _configurationProvider;

        public RectTransform Transform => _view.Transform;
        
        public async UniTask Activate(CancellationToken cancellation)
        {
            _view.ModeSelection.SetMode(_configurationProvider.Mode);
            _view.Navigation.Enable();
            _view.ModeSelection.Selected += OnModeSelected;
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
    }
}