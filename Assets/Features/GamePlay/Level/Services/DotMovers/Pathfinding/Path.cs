using System.Collections.Generic;
using GamePlay.Level.Cells.Runtime;

namespace GamePlay.Level.Services.DotMovers.Pathfinding
{
    public readonly struct Path
    {
        public Path(IReadOnlyList<ICell> cells, bool isValid)
        {
            Cells = cells;
            IsValid = isValid;
        }

        public readonly IReadOnlyList<ICell> Cells;
        public readonly bool IsValid;
    }
}