using System;
using System.Threading;
using Common.Architecture.Local.Abstract.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Services.Score.Runtime;
using Global.System.ApplicationProxies.Runtime;
using Global.System.MessageBrokers.Runtime;

namespace GamePlay.UI.Runtime.Score
{
    public class LevelUiController : ILevelUiController, ILocalSwitchListener
    {
        public LevelUiController(ILevelUiView view, IScreen screen)
        {
            _view = view;
            _screen = screen;
        }

        private readonly ILevelUiView _view;
        private readonly IScreen _screen;

        private CancellationTokenSource _cancellation;
        private IDisposable _listener;

        public void OnEnabled()
        {
            _listener = Msg.Listen<ScoreUpdatedEvent>(OnScoreUpdated);
            
            if (_screen.ScreenMode == ScreenMode.Vertical)
                _view.HidePillows();
        }

        public void OnDisabled()
        {
            _listener?.Dispose();
            _cancellation?.Cancel();
            _cancellation?.Dispose();
        }

        private void OnScoreUpdated(ScoreUpdatedEvent payload)
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();

            _cancellation = new CancellationTokenSource();

            _view.UpdateScore(
                    payload.PlayerScore,
                    payload.EnemyScore,
                    _screen.ScreenMode, 
                    _cancellation.Token).Forget();
        }

        public void SetAvatars(ParticipantsAvatars avatars)
        {
            _view.UpdateAvatars(avatars.Player, avatars.Enemy);
        }
    }
}