using System.Collections.Generic;
using GamePlay.Level.Cells.Runtime;
using GamePlay.Level.Dots.Runtime;

namespace GamePlay.Level.Fields.Runtime
{
    public interface IField
    {
        IReadOnlyList<IReadOnlyList<ICell>> Cells { get; }

        void OnCellTaken(ICell cell);
        void OnDotCleared(IDot dot);

        ICell GetRandomAvailableCell();
        ICell FindParentCell(IDot dot);
        ICell FindNearestAvailableCell(IDot dot);
    }
}