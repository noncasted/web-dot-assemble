using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Menu.Achievements.UI
{
    [DisallowMultipleComponent]
    public class AchievementProgressBar : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float _speed = 1f;
        [SerializeField] private RectTransform _transform;
        
        private float _startX;
            
        private void Awake()
        {
            _startX = _transform.offsetMax.x;
        }

        private void OnDisable()
        {
            var offset = _transform.offsetMax;
            offset.x = _startX;
            _transform.offsetMax = offset;
        }

        public async UniTask UpdateProgress(float targetProgress, CancellationToken cancellation)
        {
            var progress = 0f;
            
            while (progress < 1f && cancellation.IsCancellationRequested == false)
            {
                var offset = _transform.offsetMax;
                progress += Time.deltaTime * _speed;
                
                offset.x = Mathf.Lerp(_startX, _startX - _startX * targetProgress, progress);
                _transform.offsetMax = offset;
                
                await UniTask.Yield();
            }
        }
    }
}