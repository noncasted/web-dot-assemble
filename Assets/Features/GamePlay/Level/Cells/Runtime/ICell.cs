using System.Collections.Generic;
using GamePlay.Level.Dots.Runtime;
using UnityEngine;

namespace GamePlay.Level.Cells.Runtime
{
    public interface ICell
    {
        RectTransform Transform { get; }
        Vector2Int Position { get; }
        float Priority { get; set; }
        IReadOnlyList<ICell> Neighbours { get; }
        IDot Dot { get; }

        void Construct(Vector2Int position, IReadOnlyList<ICell> neighbours);

        void ClearDot();
        void SetDot(IDot dot);
        void MarkAsPath();
    }
}