using System.Linq;
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
        public PathSelector(IDot dot, IField field, IUpdater updater, IMouseInput mouseInput, Transform root)
        {
            _field = field;
            _updater = updater;
            _mouseInput = mouseInput;
            _root = root;
            _start = field.FindParentCell(dot);
            _pathfinder = new Pathfinder();
            _completion = new UniTaskCompletionSource<Path>();

            Path = Search();
        }

        private readonly IField _field;
        private readonly IUpdater _updater;
        private readonly IMouseInput _mouseInput;
        private readonly Transform _root;
        private readonly ICell _start;
        private readonly Pathfinder _pathfinder;
        private readonly UniTaskCompletionSource<Path> _completion;

        public Path Path { get; private set; }

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
            Path = Search();
        }

        private Path Search()
        {
            ClearCells();

            var localPoint = _mouseInput.GetWorldPoint();

            var nearest = GetNearest(localPoint);

            var path = _pathfinder.Search(_start, nearest);

            for (var i = 1; i < path.Cells.Count; i++)
            {
                var cell = path.Cells[i];
                
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
                var distance = Vector2.Distance(cell.Transform.position, position);

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