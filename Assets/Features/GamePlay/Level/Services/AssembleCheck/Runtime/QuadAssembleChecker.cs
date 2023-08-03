using System.Collections.Generic;
using GamePlay.Level.Cells.Runtime;
using GamePlay.Level.Dots.Definitions;
using GamePlay.Level.Dots.Destroyer;
using GamePlay.Level.Fields.Runtime;
using UnityEngine;

namespace GamePlay.Level.Services.AssembleCheck.Runtime
{
    public class QuadAssembleChecker : IAssembleChecker
    {
        public QuadAssembleChecker(IField field, IDotDestroyer dotDestroyer)
        {
            _field = field;
            _dotDestroyer = dotDestroyer;
        }

        private readonly IField _field;
        private readonly IDotDestroyer _dotDestroyer;

        public void CheckAssemble()
        {
            foreach (var cell in _field.Cells)
            {
                var result = Search(cell.Position);

                if (result.Success == false)
                    continue;

                foreach (var targetCell in result.Cells)
                    _dotDestroyer.Destroy(targetCell.Dot);
            }
        }

        private QuadSearchResult Search(Vector2Int startPosition)
        {
            var up = new Vector2Int(startPosition.x, startPosition.y + 1);
            var diagonal = new Vector2Int(startPosition.x + 1, startPosition.y + 1);
            var right = new Vector2Int(startPosition.x + 1, startPosition.y);

            var progress = 0;
            IDotDefinition definition = null;

            progress += CheckCell(startPosition, out var startCell);
            progress += CheckCell(up, out var upCell);
            progress += CheckCell(diagonal, out var diagonalCell);
            progress += CheckCell(right, out var rightCell);

            int CheckCell(Vector2Int position, out ICell result)
            {
                if (_field.Grid.TryGetValue(position, out result) == false)
                    return 0;

                var dot = result.Dot;

                if (dot == null)
                    return 0;

                if (dot.LifeFlow.IsActive == false)
                    return 0;

                if (definition != null && dot.Definition != definition)
                    return 0;

                definition ??= dot.Definition;

                return 1;
            }

            if (progress != 4)
                return new QuadSearchResult(false);

            var cells = new[]
            {
                startCell, upCell, diagonalCell, rightCell
            };

            return new QuadSearchResult(cells);
        }

        public readonly struct QuadSearchResult
        {
            public QuadSearchResult(bool success)
            {
                Cells = new List<ICell>();
                Success = success;
            }

            public QuadSearchResult(IReadOnlyList<ICell> cells)
            {
                Cells = cells;
                Success = true;
            }

            public readonly IReadOnlyList<ICell> Cells;
            public readonly bool Success;
        }
    }
}