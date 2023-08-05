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
            await _playerView.SetScore(player, player / (float)enemy, cancellationToken);
            _enemyView.SetScorePermanent(enemy);
        }

        public void UpdateAvatars(Sprite player, Sprite enemy)
        {
            _playerView.SetAvatar(player);
            _enemyView.SetAvatar(enemy);
        }
    }
}