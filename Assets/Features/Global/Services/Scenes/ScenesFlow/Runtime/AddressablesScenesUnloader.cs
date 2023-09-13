using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Global.Scenes.ScenesFlow.Handling.Result;
using Global.Scenes.ScenesFlow.Logs;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using UnityEngine.AddressableAssets;

namespace Global.Scenes.ScenesFlow.Runtime
{
    public class AddressablesScenesUnloader : ISceneUnloader
    {
        public AddressablesScenesUnloader(ScenesFlowLogger logger)
        {
            _logger = logger;
        }

        private readonly ScenesFlowLogger _logger;

        public async UniTask Unload(SceneLoadResult result)
        {
            if (result == null)
                return;

            _logger.OnSceneUnload(result.Scene);
            
            await Addressables.UnloadSceneAsync(result.SceneInstance);
        }

        public async UniTask Unload(IReadOnlyList<SceneLoadResult> scenes)
        {
            var tasks = new UniTask[scenes.Count];

            for (var i = 0; i < scenes.Count; i++)
                tasks[i] = Unload(scenes[i]);

            await UniTask.WhenAll(tasks);
        }
    }
}