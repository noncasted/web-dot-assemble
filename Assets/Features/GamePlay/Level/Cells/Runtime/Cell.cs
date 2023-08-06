using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Dots.Runtime;
using UnityEngine;

namespace GamePlay.Level.Cells.Runtime
{
    [DisallowMultipleComponent]
    public class Cell : MonoBehaviour, ICell
    {
        [SerializeField] private Transform _dotParent;
        [SerializeField] private Color _validColor;
        [SerializeField] private Color _invalidColor;
        [SerializeField] private SpriteRenderer _plate;
        [SerializeField] private Vector2Int _position;
        
        [SerializeField] private SpriteRenderer _pathTraveledMark;
        [SerializeField] private float _pathTraveledMarkSwitchTime = 0.3f; 
        [SerializeField] private float _pathTraveledMarkTime = 1f; 
        
        private Color _baseColor;
        private CancellationTokenSource _pathTraveledMarkCancellation;

        private Transform _transform;
        private IReadOnlyList<ICell> _neighbours;
        private IDot _dot;
        private float _distanceToTarget;
        private ICell _previousNode;

        public Transform Transform => _transform;

        public Vector2Int Position => _position;

        public IReadOnlyList<ICell> Neighbours => _neighbours;

        public IDot Dot => _dot;

        public float DistanceToTarget => _distanceToTarget;

        public ICell PreviousNode => _previousNode;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            
            var color = _pathTraveledMark.color;
            color.a = 0f;
            _pathTraveledMark.color = color;
            
            _baseColor = _plate.color;
        }

        public void Construct(Vector2Int position, IReadOnlyList<ICell> neighbours)
        {
            _position = position;
            _neighbours = neighbours;
        }

        public void SetPreviousNode(ICell cell)
        {
            _previousNode = cell;
        }

        public void ClearDot()
        {
            _dot = null;
        }

        public void SetDot(IDot dot)
        {
            _dot = dot;
            _dot.View.Transform.parent = _dotParent;
            _dot.View.Transform.localPosition = Vector3.zero;
        }

        public void SetDistanceCost(float distance)
        {
            _distanceToTarget = distance;
        }

        public void MarkAsValid()
        {
            _plate.color = _validColor;
        }

        public void MarkAsInvalid()
        {
            _plate.color = _invalidColor;
        }

        public void ClearMark()
        {
            _plate.color = _baseColor;
            _previousNode = null;
            _distanceToTarget = float.MaxValue;
        }

        public void MarkAsTraveled()
        {
            _pathTraveledMarkCancellation?.Cancel();
            _pathTraveledMarkCancellation?.Dispose();
            _pathTraveledMarkCancellation = new CancellationTokenSource();

            ProcessPathTraveledMark().Forget();
        }

        private async UniTask ProcessPathTraveledMark()
        {
            await SwitchImage(_pathTraveledMark, 0f, 1f, _pathTraveledMarkSwitchTime);
            var time = Mathf.RoundToInt(_pathTraveledMarkTime * 1000);
            await UniTask.Delay(time);
            await SwitchImage(_pathTraveledMark, 1f, 0f, _pathTraveledMarkSwitchTime);
        }

        private async UniTask SwitchImage(SpriteRenderer image, float startAlpha, float endAlpha, float time)
        {
            var currentTime = 0f;
            var progress = 0f;

            while (progress < 1f)
            {
                currentTime += Time.deltaTime;
                progress = currentTime / time;

                var color = image.color;
                color.a = Mathf.Lerp(startAlpha, endAlpha, progress);
                image.color = color;
                
                await UniTask.Yield(_pathTraveledMarkCancellation.Token);
            }
        }
    }
}