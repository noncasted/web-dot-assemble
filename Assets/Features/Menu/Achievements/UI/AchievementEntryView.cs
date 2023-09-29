using System;
using System.Threading;
using Common.UI.Buttons;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Menu.Achievements.Definitions;
using Menu.Common.Pages;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Achievements.UI
{
    [DisallowMultipleComponent]
    public class AchievementEntryView : PageEntry<IAchievement>
    {
        [SerializeField] private Image _icon;
        [SerializeField] private ExtendedTriggerReceiver _triggerReceiver;
        [SerializeField] private AchievementEntryViewConfig _config;
        
        private IAchievement _achievement;

        public event Action<IAchievement> Selected; 

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _triggerReceiver.PointerUp += OnSelected;
        }

        private void OnDisable()
        {
            _triggerReceiver.PointerUp -= OnSelected;
        }

        public override async UniTask Show(IAchievement achievement, CancellationToken cancellation)
        {
            _achievement = achievement;
            gameObject.SetActive(true);
            _icon.sprite = achievement.Data.Icon;
            transform.localScale = Vector3.zero;
            
            await transform
                .DOScale(Vector3.one, _config.ShowTime)
                .SetEase(Ease.InCirc)
                .Play()
                .ToUniTask(TweenCancelBehaviour.Kill, cancellation);
        }

        public override async UniTask Hide(CancellationToken cancellation)
        {
            _achievement = null;
            
            await transform
                .DOScale(Vector3.zero, _config.HideTime)
                .SetEase(Ease.OutCubic)
                .Play()
                .ToUniTask(TweenCancelBehaviour.Kill, cancellation);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        private void OnSelected()
        {
            if (_achievement == null)
                return;
            
            Selected?.Invoke(_achievement);
        }
    }
}