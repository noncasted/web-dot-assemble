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

        private void Awake()
        {
            _baseScale = transform.localScale;
            _transform = GetComponent<RectTransform>();
        }

        public RectTransform Transform => _transform;

        public void Grow(int currentCycle, int maxCycle)
        {
            var progress = currentCycle / (float)maxCycle;

            progress = Mathf.Clamp01(progress);

            transform.DOScale(_baseScale * progress, _scaleTime)
                .SetEase(Ease.InBounce);
        }

        public async UniTask Destroy()
        {
            var cancellation = gameObject.GetCancellationTokenOnDestroy();

            await transform.DOScale(Vector3.zero, _scaleTime)
                .SetEase(Ease.InBounce).Play().ToUniTask(cancellationToken: cancellation);
        }
    }
}