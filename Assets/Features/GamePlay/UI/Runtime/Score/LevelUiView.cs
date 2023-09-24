using System.Collections.Generic;
using System.Threading;
using Common.UI.Extended.ProgressBars;
using Cysharp.Threading.Tasks;
using Global.System.ApplicationProxies.Runtime;
using TMPro;
using UnityEngine;

namespace GamePlay.UI.Runtime.Score
{
    [DisallowMultipleComponent]
    public class LevelUiView : MonoBehaviour, ILevelUiView
    {
        [SerializeField] private ParticipantScoreView _playerView;
        [SerializeField] private ParticipantScoreView _enemyView;

        [SerializeField] private ProgressBar _progress;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private StarsDictionary _stars;
        
        public void HidePillows()
        {
            _playerView.Disable();
            _enemyView.Disable();
        }

        public async UniTask UpdateScore(int player, int enemy, ScreenMode screenMode, CancellationToken cancellation)
        {
            var tasks = new List<UniTask>();
            var progress = player / (float)enemy;
            _scoreText.text = player.ToString();

            if (screenMode == ScreenMode.Horizontal)
            {
                var playerTask = _playerView.SetScore(player, progress, cancellation);
                var enemyTask = _enemyView.SetScore(enemy, 1f - progress, cancellation);
                tasks.Add(playerTask);
                tasks.Add(enemyTask);
            }

            var progressTask = _progress.UpdateProgress(progress, cancellation);
            tasks.Add(progressTask);

            foreach (var (requiredProgress, star) in _stars)
            {
                if (progress < requiredProgress)
                    continue;

                tasks.Add(star.Show(cancellation));
            }

            await UniTask.WhenAll(tasks);
        }

        public void UpdateAvatars(Sprite player, Sprite enemy)
        {
            _playerView.SetAvatar(player);
            _enemyView.SetAvatar(enemy);
        }
    }
}