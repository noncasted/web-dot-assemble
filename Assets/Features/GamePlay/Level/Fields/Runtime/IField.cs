using System.Collections.Generic;
using GamePlay.Level.Cells.Runtime;
using GamePlay.Level.Dots.Runtime;
using UnityEngine;

namespace GamePlay.Level.Fields.Runtime
{
    public interface IField
    {
        IReadOnlyList<ICell> Cells { get; }
        IReadOnlyDictionary<Vector2Int, ICell> Grid { get; }

        void OnCellTaken(ICell cell);
        void OnDotCleared(IDot dot);

        ICell GetRandomAvailableCell();
        ICell FindParentCell(IDot dot);
        ICell FindNearestAvailableCell(Vector2 position);
        void RemoveDot(IDot dot);
    }
}