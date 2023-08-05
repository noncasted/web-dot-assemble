using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Cells.Runtime;
using GamePlay.Level.Dots.Runtime;
using GamePlay.Level.Dots.Runtime.DragHandlers;
using GamePlay.Level.Fields.Runtime;
using GamePlay.Level.Services.DotMovers.Pathfinding;
using Global.Services.Inputs.View.Runtime.Mouses;
using Global.Services.System.MessageBrokers.Runtime;
using Global.Services.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Level.Services.DotMovers.Runtime
{
    public class DotMover : IDotMover
    {
        public DotMover(
            IUpdater updater,
            IMouseInput mouseInput,
            IMoveRectProvider moveRectProvider,
            IDotMoverConfig config)
        {
            _updater = updater;
            _mouseInput = mouseInput;
            _moveRectProvider = moveRectProvider;
            _config = config;
        }

        private readonly IUpdater _updater;
        private readonly IMouseInput _mouseInput;
        private readonly IMoveRectProvider _moveRectProvider;
        private readonly IDotMoverConfig _config;

        public async UniTask<UniTask> TryMove(IField field, CancellationToken cancellation)
        {
            var completionSource = new UniTaskCompletionSource<IDot>();

            void OnDotDragged(DotDraggedEvent payload)
            {
                var dot = payload.Dot;
                completionSource.TrySetResult(dot);
            }

            var dragListener = Msg.Listen<DotDraggedEvent>(OnDotDragged);

            cancellation.Register(dragListener.Dispose);
            cancellation.Register(() => completionSource.TrySetCanceled());

            var dot = await completionSource.Task;

            return ProcessMove(field, dot, cancellation);
        }

        private async UniTask ProcessMove(IField field, IDot dot, CancellationToken cancellation)
        {
            var moveProcessor = new PathSelector(dot, field, _updater, _mouseInput, _moveRectProvider.MoveRect);

            moveProcessor.Start();
            await _mouseInput.WaitLeftDownAsync(cancellation);
            moveProcessor.Dispose();

            var path = moveProcessor.Path;

            if (path.Cells == null || path.Cells.Count == 1)
                return;

            var startCell = field.FindParentCell(dot);
            var endCell = field.FindNearestAvailableCell(path.Cells.Last().Transform.anchoredPosition);

            await UniTask.Delay(100, cancellationToken: cancellation);

            startCell.ClearDot();

            dot.View.Transform.parent = _moveRectProvider.MoveRect;
            await MoveDotAlongPath(dot, path, cancellation);

            endCell.SetDot(dot);

            foreach (var cell in field.Cells)
                cell.ClearMark();

            field.OnDotCleared(dot);
            field.OnCellTaken(endCell);
        }

        private async UniTask MoveDotAlongPath(IDot dot, Path path, CancellationToken cancellation)
        {
            var count = path.Cells.Count();

            await MoveBounce(dot, path.Cells[1], path.Cells[0], _config.BounceTime, cancellation);

            for (var i = 0; i < count - 1; i++)
            {
                var from = path.Cells[i];
                var to = path.Cells[i + 1];

                var progress = i / (float)count;
                var time = _config.StepTime * _config.Curve.Evaluate(progress);

                await MoveDotBetweenCells(dot, from, to, time, cancellation);
            }
            
            await MoveBounce(dot, path.Cells[^2], path.Cells[^1], _config.BounceTime, cancellation);
        }

        private async UniTask MoveDotBetweenCells(
            IDot dot,
            ICell from,
            ICell to, 
            float time,
            CancellationToken cancellation)
        {
            var fromPosition = from.Transform.anchoredPosition;
            var toPosition = to.Transform.anchoredPosition;

            await MoveDot(dot, fromPosition, toPosition, time, cancellation);

        }

        private async UniTask MoveBounce(
            IDot dot,
            ICell from, 
            ICell to, 
            float time,
            CancellationToken cancellation)
        {
            var fromPosition = from.Transform.anchoredPosition;
            var toPosition = to.Transform.anchoredPosition;
            var direction = (toPosition - fromPosition).normalized;

            var bouncePosition = toPosition + direction * _config.BounceDistance;

            await MoveDot(dot, toPosition, bouncePosition, time, cancellation);
            await MoveDot(dot, bouncePosition, toPosition, time, cancellation);
        }

        private async UniTask MoveDot(
            IDot dot,
            Vector2 fromPosition,
            Vector2 toPosition,
            float time,
            CancellationToken cancellation)
        {
            var currentTime = 0f;
            var progress = 0f;

            while (progress < 1f)
            {
                currentTime += Time.deltaTime;
                progress = currentTime / time;

                var position = Vector2.Lerp(fromPosition, toPosition, progress);
                dot.View.Transform.anchoredPosition = position;

                await UniTask.Yield(cancellation);
            }
        }
    }
}