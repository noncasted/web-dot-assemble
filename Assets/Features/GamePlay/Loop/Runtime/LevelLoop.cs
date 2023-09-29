using System.Threading;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Fields.Factory;
using GamePlay.Level.Services.AssembleCheck.Runtime;
using GamePlay.Level.Services.FieldFlow.Runtime;
using GamePlay.Level.Services.Score.Runtime;
using GamePlay.Loop.Logs;
using GamePlay.UI.Runtime.Score;
using Global.LevelConfigurations.Runtime;

namespace GamePlay.Loop.Runtime
{
    public class LevelLoop : IScopeLoadAsyncListener
    {
        public LevelLoop(
            IFieldFlow flow,
            ILevelConfigurationProvider configurationProvider,
            ILevelUiController levelUiController,
            IScore score,
            LevelLoopLogger logger)
        {
            _flow = flow;
            _configurationProvider = configurationProvider;
            _levelUiController = levelUiController;
            _score = score;
            _logger = logger;
        }

        private readonly IFieldFlow _flow;
        private readonly ILevelConfigurationProvider _configurationProvider;
        private readonly ILevelUiController _levelUiController;
        private readonly IScore _score;
        private readonly IFieldFactory _fieldFactory;
        private readonly IAssembleChecker _assembleChecker;
        private readonly LevelLoopLogger _logger;

        private CancellationTokenSource _cancellation;

        public async UniTask OnLoadedAsync()
        {
            var configuration = await _configurationProvider.GetConfiguration();
            
            var avatars = new ParticipantsAvatars(
                _configurationProvider.PlayerAvatar.Sprite, 
                configuration.Enemy.Sprite);
            
            _levelUiController.SetAvatars(avatars);
            _score.SetEnemyScore(configuration.TargetScore);
            
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