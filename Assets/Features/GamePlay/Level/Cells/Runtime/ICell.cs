using System.Collections.Generic;
using GamePlay.Level.Dots.Runtime;
using UnityEngine;

namespace GamePlay.Level.Cells.Runtime
{
    public interface ICell
    {
        Transform Transform { get; }
        Vector2Int Position { get; }
        IReadOnlyList<ICell> Neighbours { get; }
        IDot Dot { get; }

        float DistanceToTarget {get;}

        public ICell PreviousNode { get; }

        void Construct(Vector2Int position, IReadOnlyList<ICell> neighbours);

        void SetPreviousNode(ICell cell);
        void ClearDot();
        void SetDot(IDot dot);
        void SetDistanceCost(float distance);
        void MarkAsValid();
        void MarkAsInvalid();
        void ClearMark();
        void MarkAsTraveled();
    }
}