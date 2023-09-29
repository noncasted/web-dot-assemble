using Common.Architecture.Mocks.Runtime;
using Common.Architecture.ScopeLoaders.Factory;
using Cysharp.Threading.Tasks;
using GamePlay.Config.Runtime;
using GamePlay.Loop.Modes;
using Global.LevelConfigurations.Avatars;
using Global.LevelConfigurations.Runtime;
using UnityEngine;
using VContainer;

namespace GamePlay.Common.GlobalBootstrapMocks
{
    [DisallowMultipleComponent]
    public class LevelGlobalMock : MockBase
    {
        [SerializeField] private LevelConfig _level;
        [SerializeField] private GlobalMock _mock;
        [SerializeField] private AvatarDefinition _avatar;
        [SerializeField] private GameMode _gameMode;
        
        public override async UniTaskVoid Process()
        {
            var result = await _mock.BootstrapGlobal();
            await BootstrapLocal(result);
        }

        private async UniTask BootstrapLocal(MockBootstrapResult result)
        {
            var scopeLoaderFactory = result.Resolver.Resolve<IScopeLoaderFactory>();
            var scopeLoader = scopeLoaderFactory.Create(_level, result.Parent);
            var scope = await scopeLoader.Load();

            var configurationProvider = scope.Scope.Container.Resolve<ILevelConfigurationProvider>();
            configurationProvider.SetPlayerAvatar(_avatar);
            configurationProvider.SetMode(_gameMode);
            
            await result.RegisterLoadedScene(scope);
        }
    }
}