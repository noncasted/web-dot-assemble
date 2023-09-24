using System.Collections.Generic;
using GamePlay.Level.Cells.Runtime;
using GamePlay.Level.Fields.Lifetime;
using GamePlay.Level.Fields.Runtime;
using UnityEngine;

namespace GamePlay.Level.Fields.Factory
{
    public class FieldFactory : IFieldFactory
    {
        public FieldFactory(Transform cellsRoot)
        {
            _cellsRoot = cellsRoot;
        }

        private readonly Transform _cellsRoot;

        public IField Create(IFieldScanner scanner, IFieldValidator validator)
        {
            var cells = scanner.Scan(_cellsRoot);

            var gridData = GetGridData(cells);
            var grid = ConstructCells(cells, gridData);
            validator.Validate(cells);
            
            var lifetime = new FieldLifetime();
            var field = new Field(lifetime, cells, grid);

            return field;
        }

        private GridData GetGridData(ICell[] cells)
        {
            var minX = float.MaxValue;
            var maxX = float.MinValue;
            var minY = float.MaxValue;
            var maxY = float.MinValue;

            var rowElements = new Dictionary<float, int>();
            var columnElements = new Dictionary<float, int>();
            var maxRowElementsCount = 0;
            var maxColumnElementsCount = 0;

            foreach (var cell in cells)
            {
                var cellPosition = cell.Transform.position;
                var intX = Mathf.CeilToInt(cellPosition.x * 1000);
                var intY = Mathf.CeilToInt(cellPosition.y * 1000);

                rowElements.TryAdd(intY, 0);
                columnElements.TryAdd(intX, 0);

                rowElements[intY]++;
                columnElements[intX]++;
            }

            foreach (var (_, value) in rowElements)
            {
                if (value > maxRowElementsCount)
                    maxRowElementsCount = value;
            }

            foreach (var (_, value) in columnElements)
            {
                if (value > maxColumnElementsCount)
                    maxColumnElementsCount = value;
            }

            foreach (var cell in cells)
            {
                var anchoredPosition = cell.Transform.position;

                var x = anchoredPosition.x;
                var y = anchoredPosition.y;

                if (x < minX)
                    minX = x;

                if (x > maxX)
                    maxX = x;

                if (y < minY)
                    minY = y;

                if (y > maxY)
                    maxY = y;
            }

            return new GridData
            {
                MinX = minX,
                MinY = minY,
                StepX = (maxX - minX) / (maxRowElementsCount - 1),
                StepY = (maxY - minY) / (maxColumnElementsCount - 1),
            };
        }

        private IReadOnlyDictionary<Vector2Int, ICell> ConstructCells(ICell[] cells, GridData gridData)
        {
            var mappedCells = new Dictionary<Vector2Int, ICell>();

            foreach (var cell in cells)
            {
                var rowPosition = cell.Transform.position;

                var x = Mathf.RoundToInt((rowPosition.x - gridData.MinX) / gridData.StepX);
                var y = Mathf.RoundToInt((rowPosition.y - gridData.MinY) / gridData.StepY);
                var position = new Vector2Int(x, y);
                mappedCells[position] = cell;
            }

            foreach (var (position, cell) in mappedCells)
            {
                var neighbours = new List<ICell>();

                var up = new Vector2Int(position.x, position.y + 1);
                var right = new Vector2Int(position.x + 1, position.y);
                var down = new Vector2Int(position.x, position.y - 1);
                var left = new Vector2Int(position.x - 1, position.y);

                if (mappedCells.TryGetValue(up, out var upNeighbour))
                    neighbours.Add(upNeighbour);

                if (mappedCells.TryGetValue(right, out var rightNeighbour))
                    neighbours.Add(rightNeighbour);

                if (mappedCells.TryGetValue(down, out var downNeighbour))
                    neighbours.Add(downNeighbour);

                if (mappedCells.TryGetValue(left, out var leftNeighbour))
                    neighbours.Add(leftNeighbour);

                cell.Construct(position, neighbours);
            }

            return mappedCells;
        }

        private struct GridData
        {
            public float MinX;
            public float StepX;

            public float MinY;
            public float StepY;
        }
    }
}