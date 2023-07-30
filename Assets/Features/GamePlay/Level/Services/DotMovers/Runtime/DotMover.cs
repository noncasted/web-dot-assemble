using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Dots.Runtime;
using GamePlay.Level.Dots.Runtime.DragHandlers;
using GamePlay.Level.Fields.Runtime;
using GamePlay.Level.Services.DotMovers.Pathfinding;
using Global.Services.Inputs.View.Runtime.Mouses;
using Global.Services.System.MessageBrokers.Runtime;
using Global.Services.System.Updaters.Runtime.Abstract;

namespace GamePlay.Level.Services.DotMovers.Runtime
{
    public class DotMover : IDotMover
    {
        public DotMover(IUpdater updater, IMouseInput mouseInput, IMoveRectProvider moveRectProvider)
        {
            _updater = updater;
            _mouseInput = mouseInput;
            _moveRectProvider = moveRectProvider;
        }

        private readonly IUpdater _updater;
        private readonly IMouseInput _mouseInput;
        private readonly IMoveRectProvider _moveRectProvider;

        public async UniTask<UniTask> TryMove(IField field, CancellationToken cancellation)
        {
            var start = field.GetRandomAvailableCell();
            var end = field.GetRandomAvailableCell();

            var path = AStar.Search(start, end);

            foreach (var cell in path)
                cell.MarkAsPath();

            var completionSource = new UniTaskCompletionSource<IDot>();

            void OnDotDragged(DotDraggedEvent payload)
            {
                var dot = payload.Dot;
                completionSource.TrySetResult(dot);
            }

            var dragListener = Msg.Listen<DotDraggedEvent>(OnDotDragged);

            cancellation.Register(dragListener.Dispose);
            cancellation.Register(() => completionSource.TrySetCanceled());

            var dot =  await completionSource.Task;

            return ProcessMove(field, dot, cancellation);
        }

        private async UniTask ProcessMove(IField field, IDot dot, CancellationToken cancellation)
        {
            var moveProcessor = new MoveProcessor(dot, _updater, _mouseInput, _moveRectProvider.MoveRect);

            moveProcessor.Start();
            await _mouseInput.WaitLeftUpAsync(cancellation);
            moveProcessor.Dispose();

            var startCell = field.FindParentCell(dot);
            var endCell = field.FindNearestAvailableCell(dot);

            startCell.ClearDot();
            endCell.SetDot(dot);

            field.OnCellTaken(endCell);
            field.OnDotCleared(dot);
        }
    }
}