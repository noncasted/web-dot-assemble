using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Global.Publisher.Abstract.Leaderboards;
using TMPro;
using UnityEngine;

namespace Menu.Leaderboards.UI
{
    [DisallowMultipleComponent]
    public class LeaderboardEntry : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float _switchTime = 0.3f;
        
        [SerializeField] private RectTransform _body;
        [SerializeField] private TMP_Text _rank;
        [SerializeField] private TMP_Text _score;
        [SerializeField] private TMP_Text _name;

        public async UniTask Show(LeaderboardUser user, CancellationToken cancellation)
        {
            _rank.text = user.Rank.ToString();
            _score.text = user.Score.ToString();
            _name.text = user.PlayerName;
            
            await transform
                .DOScale(Vector3.one, _switchTime)
                .SetEase(Ease.InCirc)
                .Play()
                .ToUniTask(TweenCancelBehaviour.Kill, cancellation);
        }

        public async UniTask Hide(CancellationToken cancellation)
        {
            await transform
                .DOScale(Vector3.zero, _switchTime)
                .SetEase(Ease.InCirc)
                .Play()
                .ToUniTask(TweenCancelBehaviour.Kill, cancellation);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }
        
        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}