using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.UI.Runtime.Score
{
    [DisallowMultipleComponent]
    public class ScoreView : MonoBehaviour, IScoreView
    {
        [SerializeField] private ParticipantScoreView _playerView;
        [SerializeField] private ParticipantScoreView _enemyView;

        public async UniTask UpdateScore(int player, int enemy, CancellationToken cancellationToken)
        {
            var targetProgress = player / (float)enemy;
            var playerTask = _playerView.SetScore(player, targetProgress, cancellationToken);
            var enemyTask = _enemyView.SetScore(enemy, 1f - targetProgress, cancellationToken);

            await UniTask.WhenAll(playerTask, enemyTask);
        }

        public void UpdateAvatars(Sprite player, Sprite enemy)
        {
            _playerView.SetAvatar(player);
            _enemyView.SetAvatar(enemy);
        }
    }
}