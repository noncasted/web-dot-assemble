using System;
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
        [SerializeField] private AchievementEntryViewEventsReceiver _eventsReceiver;
        [SerializeField] private AchievementEntryViewConfig _config;
        
        private IAchievement _achievement;

        public event Action<IAchievement> Selected; 
        public event Action Deselected; 

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _eventsReceiver.Down += OnDown;
            _eventsReceiver.Up += OnUp;
        }

        private void OnDisable()
        {
            _eventsReceiver.Down -= OnDown;
            _eventsReceiver.Up -= OnUp;
        }

        public async UniTask Show(IAchievement achievement, CancellationToken cancellation)
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

        public async UniTask Hide(CancellationToken cancellation)
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

        private void OnDown()
        {
            if (_achievement == null)
                return;
            
            Selected?.Invoke(_achievement);
        }
        
        private void OnUp()
        {
            Deselected?.Invoke();
        }
    }
}