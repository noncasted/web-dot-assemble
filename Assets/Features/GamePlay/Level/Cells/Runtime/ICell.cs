using System.Collections.Generic;
using GamePlay.Level.Dots.Runtime;
using UnityEngine;

namespace GamePlay.Level.Cells.Runtime
{
    public interface ICell
    {
        RectTransform Transform { get; }
        Vector2Int Position { get; }
        IReadOnlyList<ICell> Neighbours { get; }
        IDot Dot { get; }

        float DistanceToTarget {get;}

        public ICell PreviousNode { get; set; }

        void Construct(Vector2Int position, IReadOnlyList<ICell> neighbours);

        void ClearDot();
        void SetDot(IDot dot);
        void SetDistanceCost(float distance);
        void MarkAsValid();
        void MarkAsInvalid();
        void ClearMark();
    }
}