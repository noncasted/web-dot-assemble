using Common.Architecture.Mocks;
using Cysharp.Threading.Tasks;
using Features.Global.Services.LevelConfiguration.Avatars;
using Features.Global.Services.LevelConfiguration.Definition;
using Features.Global.Services.LevelConfiguration.Runtime;
using GamePlay.Config.Runtime;
using Global.Services.Scenes.ScenesFlow.Runtime.Abstract;
using UnityEngine;
using VContainer;

namespace GamePlay.Common.GlobalBootstrapMocks
{
    [DisallowMultipleComponent]
    public class LevelGlobalMock : MonoBehaviour
    {
        [SerializeField] private LevelConfig _level;
        [SerializeField] private GlobalMock _mock;

        [SerializeField] private AvatarDefinition _playerAvatar;
        [SerializeField] private AvatarDefinition _enemyAvatar;
        [SerializeField] private LevelConfiguration _levelConfiguration;
        
        private void Awake()
        {
            Process().Forget();
        }

        private async UniTask Process()
        {
            var result = await _mock.BootstrapGlobal();
            await BootstrapLocal(result);
        }

        private async UniTask BootstrapLocal(MockBootstrapResult result)
        {
            var configurationProvider = result.Parent.Container.Resolve<ILevelConfigurationProvider>();
            var setupConfiguration = new LevelSetupConfiguration(_playerAvatar, _enemyAvatar, _levelConfiguration);
            configurationProvider.SetConfiguration(setupConfiguration);
            
            var level
                = await _level.Load(result.Parent, result.Resolver.Resolve<ISceneLoader>());

            result.RegisterLoadedScene(level);
        }
    }
}