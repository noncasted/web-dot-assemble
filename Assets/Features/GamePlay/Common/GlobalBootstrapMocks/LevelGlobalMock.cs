using Common.Architecture.Mocks;
using Cysharp.Threading.Tasks;
using GamePlay.Config.Runtime;
using Global.LevelConfiguration.Avatars;
using Global.LevelConfiguration.Definition;
using Global.LevelConfiguration.Runtime;
using Global.Options.Runtime;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
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
            
            var sceneLoader = result.Resolver.Resolve<ISceneLoader>();
            var options = result.Resolver.Resolve<IOptions>();
            
            var level= await _level.Load(result.Parent, sceneLoader, options);

            await result.RegisterLoadedScene(level);
        }
    }
}