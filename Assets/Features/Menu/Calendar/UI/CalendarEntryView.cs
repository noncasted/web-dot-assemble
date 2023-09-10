using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Menu.Calendar.Global;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Calendar.UI
{
    [DisallowMultipleComponent]
    public class CalendarEntryView : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float _switchTime = 0.3f;
        [SerializeField] private Color _disableColor;
        [SerializeField] private Image _rewardImage;

        public async UniTask Show(ICalendarDay day, CancellationToken cancellation)
        {
            _rewardImage.sprite = day.Icon;

            if (day.IsPassed == true)
                _rewardImage.color = Color.white;
            else
                _rewardImage.color = _disableColor;
            
            await transform
                .DOScale(Vector3.one, _switchTime)
                .SetEase(Ease.InCirc)
                .Play()
                .ToUniTask(TweenCancelBehaviour.Kill, cancellation);
        }

        public void HideInstant()
        {
            transform.localScale = Vector3.zero;
        }
    }
}