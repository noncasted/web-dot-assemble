﻿using System.Linq;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Cells.Runtime;
using GamePlay.Level.Dots.Runtime;
using GamePlay.Level.Fields.Runtime;
using GamePlay.Level.Services.DotMovers.Pathfinding;
using Global.Services.Inputs.View.Runtime.Mouses;
using Global.Services.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Level.Services.DotMovers.Runtime
{
    public class PathSelector : IUpdatable
    {
        public PathSelector(IDot dot, IField field, IUpdater updater, IMouseInput mouseInput, RectTransform root)
        {
            _field = field;
            _updater = updater;
            _mouseInput = mouseInput;
            _root = root;
            _start = field.FindParentCell(dot);
            _pathfinder = new Pathfinder();
            _completion = new UniTaskCompletionSource<Path>();

            _path = Search();
        }

        private readonly IField _field;
        private readonly IUpdater _updater;
        private readonly IMouseInput _mouseInput;
        private readonly RectTransform _root;
        private readonly ICell _start;
        private readonly Pathfinder _pathfinder;
        private readonly UniTaskCompletionSource<Path> _completion;

        private Path _path;

        public Path Path => _path;

        public void Start()
        {
            _updater.Add(this);
        }

        public void Dispose()
        {
            _updater.Remove(this);
        }

        public void OnUpdate(float delta)
        {
            _path = Search();
        }

        private Path Search()
        {
            ClearCells();

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _root,
                _mouseInput.Position,
                null,
                out var localPoint);

            localPoint.x += _root.sizeDelta.x * (_root.pivot.x);
            localPoint.y += _root.sizeDelta.y * (_root.pivot.y - 1f);

            var nearest = GetNearest(localPoint);

            var path = _pathfinder.Search(_start, nearest);

            foreach (var cell in path.Cells)
            {
                if (path.IsValid == true)
                    cell.MarkAsValid();
                else
                    cell.MarkAsInvalid();
            }

            return path;
        }

        private ICell GetNearest(Vector2 position)
        {
            var minDistance = float.MaxValue;
            var nearest = _field.Cells.First();

            foreach (var cell in _field.Cells)
            {
                var distance = Vector2.Distance(cell.Transform.anchoredPosition, position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = cell;
                }
            }

            return nearest;
        }

        private void ClearCells()
        {
            foreach (var cell in _field.Cells)
                cell.ClearMark();
        }
    }
}