using Cysharp.Threading.Tasks;
using Global.Services.Scenes.ScenesFlow.Handling.Data;
using Global.Services.Scenes.ScenesFlow.Handling.Result;
using Global.Services.Scenes.ScenesFlow.Logs;
using Global.Services.Scenes.ScenesFlow.Runtime.Abstract;
using UnityEngine.SceneManagement;

namespace Global.Services.Scenes.ScenesFlow.Runtime
{
    public class ScenesLoader : ISceneLoader
    {
        public ScenesLoader(ScenesFlowLogger logger)
        {
            _logger = logger;
        }

        private readonly ScenesFlowLogger _logger;

        public async UniTask<T> Load<T>(SceneLoadData<T> scene) where T : SceneLoadResult
        {
            var targetScene = new Scene();

            SceneManager.sceneLoaded += OnSceneLoaded;

            void OnSceneLoaded(Scene loadedScene, LoadSceneMode mode)
            {
                if (loadedScene.name != scene.Name)
                    return;

                targetScene = loadedScene;
                SceneManager.sceneLoaded -= OnSceneLoaded;
            }

            var handle = SceneManager.LoadSceneAsync(scene.Name, LoadSceneMode.Additive);
            var task = handle.ToUniTask();
            await task;

            await UniTask.WaitUntil(() => targetScene.name == scene.Name);

            _logger.OnSceneLoad(targetScene);

            return scene.CreateLoadResult(targetScene);
        }
    }
}