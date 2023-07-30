using GamePlay.Level.Dots.Runtime;
using UnityEngine;

namespace GamePlay.Level.Cells.Runtime
{
    [DisallowMultipleComponent]
    public class Cell : MonoBehaviour, ICell
    {
        [SerializeField] private RectTransform _dotParent;

        private IDot _dot;
        private RectTransform _transform;

        public RectTransform Transform => _transform;
        public IDot Dot => _dot;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
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
    }
}