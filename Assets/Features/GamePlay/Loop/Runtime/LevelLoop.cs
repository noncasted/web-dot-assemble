using System.Threading;
using Common.Architecture.Local.Abstract.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Fields.Factory;
using GamePlay.Level.Services.AssembleCheck.Runtime;
using GamePlay.Level.Services.FieldFlow.Runtime;
using GamePlay.Level.Services.Score.Runtime;
using GamePlay.Loop.Logs;
using GamePlay.UI.Runtime.Score;
using Global.LevelConfiguration.Runtime;

namespace GamePlay.Loop.Runtime
{
    public class LevelLoop : ILocalLoadListener, ILocalBootstrappedListener
    {
        public LevelLoop(
            IFieldFlow flow,
            ILevelConfigurationProvider configurationProvider,
            IScoreController scoreController,
            IScore score,
            LevelLoopLogger logger)
        {
            _flow = flow;
            _configurationProvider = configurationProvider;
            _scoreController = scoreController;
            _score = score;
            _logger = logger;
        }

        private readonly IFieldFlow _flow;
        private readonly ILevelConfigurationProvider _configurationProvider;
        private readonly IScoreController _scoreController;
        private readonly IScore _score;
        private readonly IFieldFactory _fieldFactory;
        private readonly IAssembleChecker _assembleChecker;
        private readonly LevelLoopLogger _logger;

        private CancellationTokenSource _cancellation;

        public void OnBootstrapped()
        {
            var configuration = _configurationProvider.Configuration;
            var playerAvatar = configuration.PlayerAvatar;
            var enemyAvatar = configuration.EnemyAvatar;
            var avatars = new ParticipantsAvatars(playerAvatar.Sprite, enemyAvatar.Sprite);
            _scoreController.SetAvatars(avatars);
            _score.SetEnemyScore(configuration.LevelData.TargetScore);
        }
        
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