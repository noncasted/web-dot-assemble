using System.Threading;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;

namespace Menu.StateMachine.Runtime
{
    public class TabTransition : MonoBehaviour
    {
        [SerializeField] private RectTransform _target;
        [SerializeField] private RectTransform _center;
        [SerializeField] private RectTransform _tab;
        
        [SerializeField] private float _maxHeight;
        [SerializeField] [CurveRange(0f, -1f, 1f, 1f)] private AnimationCurve _heightCurve;
        [SerializeField] [CurveRange(0f, 0f, 1f, 1f)] private AnimationCurve _horizontalCurve;
        
        [SerializeField] private float _maxRotation;
        [SerializeField] [CurveRange(0f, -1f, 1f, 1f)] private AnimationCurve _rotationCurve;
        
        [SerializeField] private float _time;

        private CancellationTokenSource _cancellation;
        
        [Sirenix.OdinInspector.Button]
        private void Select()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = new CancellationTokenSource();
            
            RunAsync(_target.anchoredPosition, _center.anchoredPosition, _cancellation.Token).Forget();            
        }
        
        [Sirenix.OdinInspector.Button]
        private void Deselect()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = new CancellationTokenSource();

            DeselectAsync().Forget();
        }

        private async UniTask DeselectAsync()
        {
           await RunAsync(_center.anchoredPosition, _target.anchoredPosition, _cancellation.Token);            
        }
        
        private async UniTask RunAsync(Vector2 from, Vector2 to, CancellationToken cancellation)
        {
            var currentTime = 0f;
            var progress = 0f;

            while (progress < 1f)
            {
                currentTime += Time.deltaTime;
                progress = currentTime / _time;

                var additionalHeight = _maxHeight * _heightCurve.Evaluate(progress);
                var position = Vector2.Lerp(from, to, _horizontalCurve.Evaluate(progress));
                position.y += additionalHeight;
                _tab.anchoredPosition = position;

                var angle = _maxRotation * _rotationCurve.Evaluate(progress);
                var rotation = Quaternion.Euler(0f, 0f, angle);
                _tab.localRotation = rotation;
                
                await UniTask.Yield(cancellation);
            }
        }
    }
}