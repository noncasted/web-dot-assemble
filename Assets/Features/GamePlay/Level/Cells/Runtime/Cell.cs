using System.Collections.Generic;
using GamePlay.Level.Dots.Runtime;
using MPUIKIT;
using UnityEngine;

namespace GamePlay.Level.Cells.Runtime
{
    [DisallowMultipleComponent]
    public class Cell : MonoBehaviour, ICell
    {
        [SerializeField] private RectTransform _dotParent;
        [SerializeField] private Color _validColor;
        [SerializeField] private Color _invalidColor;
        [SerializeField] private MPImage _image;

        private IDot _dot;
        private RectTransform _transform;
        private float _distanceToTarget;
        private Color _baseColor;

        [SerializeField] private Vector2Int _position;

        private IReadOnlyList<ICell> _neighbours;

        public RectTransform Transform => _transform;
        public Vector2Int Position => _position;

        public IReadOnlyList<ICell> Neighbours => _neighbours;

        public IDot Dot => _dot;

        public float DistanceToTarget
        {
            get => _distanceToTarget;
        }

        public ICell PreviousNode { get; set; }

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
            _baseColor = _image.color;
        }

        public void Construct(Vector2Int position, IReadOnlyList<ICell> neighbours)
        {
            _position = position;
            _neighbours = neighbours;
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
            _image.color = _validColor;
        }

        public void MarkAsInvalid()
        {
            _image.color = _invalidColor;
        }

        public void ClearMark()
        {
            _image.color = _baseColor;
            PreviousNode = null;
            _distanceToTarget = float.MaxValue;
        }
    }
}