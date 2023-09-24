using Common.Architecture.Mocks.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Config.Runtime;
using Global.Options.Runtime;
using Global.Scenes.Operations.Abstract;
using UnityEngine;
using VContainer;

namespace GamePlay.Common.GlobalBootstrapMocks
{
    [DisallowMultipleComponent]
    public class LevelGlobalMock : MockBase
    {
        [SerializeField] private LevelConfig _level;
        [SerializeField] private GlobalMock _mock;

        public override async UniTaskVoid Process()
        {
            var result = await _mock.BootstrapGlobal();
            await BootstrapLocal(result);
        }

        private async UniTask BootstrapLocal(MockBootstrapResult result)
        {
            var sceneLoader = result.Resolver.Resolve<ISceneLoader>();
            var options = result.Resolver.Resolve<IOptions>();
            
            var level= await _level.Load(result.Parent, sceneLoader, options);

            await result.RegisterLoadedScene(level);
        }
    }
}