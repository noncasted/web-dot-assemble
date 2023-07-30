using GamePlay.Level.Dots.Runtime;
using UnityEngine;

namespace GamePlay.Level.Cells.Runtime
{
    public interface ICell
    {
        RectTransform Transform { get; }
        IDot Dot { get; }

        void ClearDot();
        void SetDot(IDot dot);
    }
}