using System.Collections.Generic;
using GamePlay.Level.Dots.Runtime;
using MPUIKIT;
using UnityEngine;

namespace GamePlay.Level.Cells.Runtime
{
    [DisallowMultipleComponent]
    public class Cell : MonoBehaviour, ICell
    {
        [SerializeField] private MPImage _image;
        [SerializeField] private Color _markedColor;
        [SerializeField] private RectTransform _dotParent;

        private IDot _dot;
        private RectTransform _transform;
        private float _priority;

        private Vector2Int _position;
        private IReadOnlyList<ICell> _neighbours;

        public RectTransform Transform => _transform;
        public Vector2Int Position => _position;
        public float Priority
        {
            get => _priority;
            set => _priority = value;
        }
        public IReadOnlyList<ICell> Neighbours => _neighbours;

        public IDot Dot => _dot;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
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

        public void MarkAsPath()
        {
            _image.color = _markedColor;
        }
    }
}