using Cysharp.Threading.Tasks;
using Global.Scenes.ScenesFlow.Handling.Data;
using Global.Scenes.ScenesFlow.Handling.Result;
using Global.Scenes.ScenesFlow.Logs;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Global.Scenes.ScenesFlow.Runtime
{
    public class AddressablesSceneLoader : ISceneLoader
    {
        public AddressablesSceneLoader(ScenesFlowLogger logger)
        {
            _logger = logger;
        }

        private readonly ScenesFlowLogger _logger;

        public async UniTask<T> Load<T>(SceneLoadData<T> scene) where T : SceneLoadResult
        {
            var sceneInstance = 
                await Addressables.LoadSceneAsync(scene.Asset.Reference, LoadSceneMode.Additive)
                .ToUniTask();

            var loadResult = scene.CreateLoadResult(sceneInstance);

            _logger.OnSceneLoad(loadResult.Scene);

            return loadResult;
        }
    }
}