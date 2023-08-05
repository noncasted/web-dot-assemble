using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Fields.Factory;
using GamePlay.Level.Fields.Lifetime;
using GamePlay.Level.Fields.Runtime;
using GamePlay.Level.Services.AssembleCheck.Factory;
using GamePlay.Level.Services.AssembleCheck.Runtime;
using GamePlay.Level.Services.DotMovers.Runtime;
using GamePlay.Level.Services.Score.Runtime;
using GamePlay.Loop.Modes;

namespace GamePlay.Level.Services.FieldFlow.Runtime
{
    public class FieldFlow : IFieldFlow
    {
        public FieldFlow(
            IDotMover dotMover,
            IFieldLifetime lifetime,
            IFieldSeeder seeder,
            IAssembleCheckFactory assembleCheckFactory,
            IField field,
            IScore score)
        {
            _dotMover = dotMover;
            _lifetime = lifetime;
            _seeder = seeder;
            _assembleChecker = assembleCheckFactory.Create(GameMode.Quads);
            _field = field;
            _score = score;
            _cancellationCallback = Stop;
        }

        private readonly IDotMover _dotMover;
        private readonly IFieldFactory _fieldFactory;
        private readonly IFieldLifetime _lifetime;
        private readonly IFieldSeeder _seeder;
        private readonly IAssembleChecker _assembleChecker;
        private readonly IField _field;
        private readonly IScore _score;

        private readonly Action _cancellationCallback;

        public async UniTask Setup(CancellationToken cancellationToken)
        {
            _seeder.SeedStartup(10);
        }

        public async UniTask Run(CancellationToken cancellation)
        {
            cancellation.Register(_cancellationCallback);

            while (cancellation.IsCancellationRequested == false)
            {
                await RunActions(cancellation);
                _lifetime.OnStep();
                _seeder.SeedInGame();

                var result = await _assembleChecker.CheckAssemble();
                _score.AddPlayerScore(result.DestroyedAmount * 2);
            }
        }

        public void Stop()
        {
        }

        private async UniTask RunActions(CancellationToken cancellation)
        {
            var actions = new List<FieldAction>();
            actions.Add(new FieldAction(_ => _dotMover.TryMove(_field, cancellation), cancellation));
            var activeActions = new List<UniTask<UniTask>>();

            foreach (var action in actions)
                activeActions.Add(action.Run());

            var result = await UniTask.WhenAny(activeActions);

            foreach (var action in actions)
            {
                if (action.IsCompleted == true)
                    continue;

                action.Cancel();
            }

            await result.result;
        }
    }

    public class FieldAction
    {
        public FieldAction(Func<CancellationToken, UniTask<UniTask>> action, CancellationToken globalCancellation)
        {
            _action = action;
            _cancellation = new CancellationTokenSource();
            globalCancellation.Register(Cancel);
        }

        private readonly Func<CancellationToken, UniTask<UniTask>> _action;

        private CancellationTokenSource _cancellation;
        private bool _isCompleted;

        public bool IsCompleted => _isCompleted;

        public async UniTask<UniTask> Run()
        {
            var result = await _action(_cancellation.Token);
            _isCompleted = true;

            return result;
        }

        public void Cancel()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}