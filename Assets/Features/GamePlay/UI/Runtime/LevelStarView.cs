using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace GamePlay.UI.Runtime
{
    [DisallowMultipleComponent]
    public class LevelStarView : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float _showTime;
        [SerializeField] private GameObject _inactive;
        [SerializeField] private Transform _active;

        private bool _isCompleted;

        private void Awake()
        {
            _active.localScale = Vector3.zero;
        }

        public async UniTask Show(CancellationToken cancellation)
        {
            if (_isCompleted == true)
                return;
            
            _isCompleted = true;
            
            await _active
                .DOScale(Vector3.one, _showTime)
                .ToUniTask(cancellationToken: cancellation);
            
            _inactive.SetActive(false);
        }
    }
}