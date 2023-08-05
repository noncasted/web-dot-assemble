using Common.UI.DoTweenExtensions;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace GamePlay.Level.Dots.Runtime.View
{
    [DisallowMultipleComponent]
    public class DotView : MonoBehaviour, IDotView
    {
        private const float _scaleTime = 0.2f;

        private RectTransform _transform;
        private Vector3 _baseScale;

        public RectTransform Transform => _transform;

        private void Awake()
        {
            _baseScale = transform.localScale;
            _transform = GetComponent<RectTransform>();
        }

        public void Grow(int currentCycle, int maxCycle)
        {
            var progress = currentCycle / (float)maxCycle;

            progress = Mathf.Clamp01(progress);

            transform.DOScale(_baseScale * progress, _scaleTime)
                .SetEase(Ease.InBounce);
        }

        public async UniTask Destroy()
        {
            await DoTweenExtensions.TweensToTask(
                transform.DOScale(Vector2.zero, _scaleTime * 3).SetEase(Ease.InBounce));
        }
    }
}