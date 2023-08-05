using System;
using System.Threading;
using Common.Architecture.Local.Services.Abstract.Callbacks;
using GamePlay.Level.Services.Score.Runtime;
using Global.Services.System.MessageBrokers.Runtime;

namespace GamePlay.UI.Runtime.Score
{
    public class ScoreController : IScoreController, ILocalSwitchListener
    {
        public ScoreController(IScoreView view)
        {
            _view = view;
        }
        
        private readonly IScoreView _view;
        
        private CancellationTokenSource _cancellation;
        private IDisposable _listener;
        
        public void OnDisabled()
        {
            _listener = Msg.Listen<ScoreUpdatedEvent>(OnScoreUpdated);
            _cancellation = new CancellationTokenSource();
        }

        public void OnEnabled()
        {
            _listener?.Dispose();
            _cancellation?.Cancel();
            _cancellation?.Dispose();
        }

        private void OnScoreUpdated(ScoreUpdatedEvent payload)
        {
            _view.UpdateScore(payload.PlayerScore, payload.EnemyScore, _cancellation.Token);
        }

        public void SetAvatars(ParticipantsAvatars avatars)
        {
            _view.UpdateAvatars(avatars.Player, avatars.Enemy);
        }
    }
}