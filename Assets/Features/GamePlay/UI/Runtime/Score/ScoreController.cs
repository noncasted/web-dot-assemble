using System;
using System.Threading;
using Common.Architecture.Local.Services.Abstract.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Services.Score.Runtime;
using Global.System.MessageBrokers.Runtime;

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

        public void OnEnabled()
        {
            _listener = Msg.Listen<ScoreUpdatedEvent>(OnScoreUpdated);
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

            _view.UpdateScore(payload.PlayerScore, payload.EnemyScore, _cancellation.Token).Forget();
        }

        public void SetAvatars(ParticipantsAvatars avatars)
        {
            _view.UpdateAvatars(avatars.Player, avatars.Enemy);
        }
    }
}