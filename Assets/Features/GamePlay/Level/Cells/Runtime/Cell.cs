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

        private Color _baseColor;

        [SerializeField] private Vector2Int _position;

        public RectTransform Transform { get; private set; }

        public Vector2Int Position => _position;

        public IReadOnlyList<ICell> Neighbours { get; private set; }

        public IDot Dot { get; private set; }

        public float DistanceToTarget { get; private set; }

        public ICell PreviousNode { get; set; }

        private void Awake()
        {
            Transform = GetComponent<RectTransform>();
            _baseColor = _image.color;
        }

        public void Construct(Vector2Int position, IReadOnlyList<ICell> neighbours)
        {
            _position = position;
            Neighbours = neighbours;
        }

        public void ClearDot()
        {
            Dot = null;
        }

        public void SetDot(IDot dot)
        {
            Dot = dot;
            Dot.View.Transform.parent = _dotParent;
            Dot.View.Transform.localPosition = Vector3.zero;
        }

        public void SetDistanceCost(float distance)
        {
            DistanceToTarget = distance;
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
            DistanceToTarget = float.MaxValue;
        }
    }
}