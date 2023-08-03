using System.Threading;
using Common.Architecture.Local.Services.Abstract.EventLoops;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Fields.Factory;
using GamePlay.Level.Fields.Runtime;
using GamePlay.Level.Services.AssembleCheck.Runtime;
using GamePlay.Level.Services.FieldFlow.Runtime;
using GamePlay.Loop.Logs;

namespace GamePlay.Loop.Runtime
{
    public class LevelLoop : ILocalLoadListener
    {
        public LevelLoop(
            IFieldFlow flow,
            IField field,
            LevelLoopLogger logger)
        {
            _flow = flow;
            _logger = logger;
        }

        private readonly IFieldFlow _flow;
        private readonly IFieldFactory _fieldFactory;
        private readonly IAssembleChecker _assembleChecker;
        private readonly LevelLoopLogger _logger;

        private CancellationTokenSource _cancellation;

        public void OnLoaded()
        {
            _logger.OnLoaded();
            _cancellation = new CancellationTokenSource();
            Begin().Forget();
        }

        private async UniTask Begin()
        {
            await _flow.Setup(_cancellation.Token);
            _flow.Run(_cancellation.Token).Forget();
        }
    }
}