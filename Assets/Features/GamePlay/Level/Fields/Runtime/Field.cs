using System;
using System.Collections.Generic;
using GamePlay.Level.Cells.Runtime;
using GamePlay.Level.Dots.Runtime;
using GamePlay.Level.Fields.Lifetime;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePlay.Level.Fields.Runtime
{
    public class Field : IField
    {
        public Field(IFieldLifetime lifetime, ICell[] allCells)
        {
            _lifetime = lifetime;
            _allCells = allCells;
            _availableCells = new List<ICell>();
            _takenCells = new Dictionary<IDot, ICell>();
            _availableCells.AddRange(allCells);
        }

        private readonly IFieldLifetime _lifetime;
        private readonly ICell[] _allCells;
        private readonly List<ICell> _availableCells;
        private readonly Dictionary<IDot, ICell> _takenCells;

        public IReadOnlyList<ICell> Cells => _allCells;

        public void OnCellTaken(ICell cell)
        {
            if (cell.Dot == null)
                throw new NullReferenceException("No dot assigned to a taken cell");

            _availableCells.Remove(cell);
            _takenCells.Add(cell.Dot, cell);
        }

        public void OnDotCleared(IDot dot)
        {
            var cell = _takenCells[dot];
            _availableCells.Add(cell);
            _takenCells.Remove(dot);
        }

        public void OnDotCleared(ICell cell)
        {
            _availableCells.Add(cell);
        }

        public ICell GetRandomAvailableCell()
        {
            var random = Random.Range(0, _availableCells.Count);
            var cell = _availableCells[random];

            return cell;
        }

        public ICell FindParentCell(IDot dot)
        {
            if (_takenCells.ContainsKey(dot) == false)
                throw new NullReferenceException("No cell found");

            return _takenCells[dot];
        }

        public ICell FindNearestAvailableCell(IDot dot)
        {
            var dotPosition = dot.View.Transform.anchoredPosition;

            var minDistance = float.MaxValue;
            ICell nearestCell = null;

            foreach (var availableCell in _availableCells)
            {
                var cellPosition = availableCell.Transform.anchoredPosition;

                var distance = Vector2.Distance(dotPosition, cellPosition);

                if (distance > minDistance)
                    continue;

                minDistance = distance;
                nearestCell = availableCell;
            }

            return nearestCell;
        }
    }
}