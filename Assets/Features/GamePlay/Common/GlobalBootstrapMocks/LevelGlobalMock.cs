using Common.Architecture.Mocks;
using Cysharp.Threading.Tasks;
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
            var level
                = await _level.Load(result.Parent, result.Resolver.Resolve<ISceneLoader>());

            result.RegisterLoadedScene(level);
        }
    }
}