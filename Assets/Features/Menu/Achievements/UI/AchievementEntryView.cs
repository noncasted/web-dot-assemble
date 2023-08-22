using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Menu.Achievements.Definitions;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Achievements.UI
{
    [DisallowMultipleComponent]
    public class AchievementEntryView : MonoBehaviour, IAchievementEntryView
    {
        [SerializeField] private Image _icon;
        [SerializeField] private AchievementEntryViewConfig _config;
        
        private IAchievement _achievement;

        public void Construct(IAchievement achievement)
        {
            _achievement = achievement;
        }

        public async UniTask Show(CancellationToken cancellation)
        {
            _icon.sprite = _achievement.Data.Icon;
            
            await transform
                .DOScale(Vector3.one, _config.ShowTime)
                .SetEase(Ease.InBounce)
                .Play()
                .ToUniTask(TweenCancelBehaviour.Kill, cancellation);
        }

        public async UniTask Hide(CancellationToken cancellation)
        {
            await transform
                .DOScale(Vector3.zero, _config.HideTime)
                .SetEase(Ease.OutBounce)
                .Play()
                .ToUniTask(TweenCancelBehaviour.Kill, cancellation);
        }
    }
}