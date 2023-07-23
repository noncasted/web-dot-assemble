using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Common.Architecture.ObjectsPools.Runtime;
using Common.Architecture.ObjectsPools.Runtime.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Services.VfxPools.Common;
using Global.Services.Scenes.ScenesFlow.Handling.Data;
using Global.Services.Scenes.ScenesFlow.Runtime.Abstract;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.VfxPools.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = VfxPoolRoutes.ServiceName, menuName = VfxPoolRoutes.ServicePath)]
    public class VfxPoolAsset : ScriptableObject, ILocalServiceAsyncFactory
    {
        [SerializeField] [Scene] [Indent] private string _scene;

        public async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            IEventLoopsRegistry callbacks)
        {
            var sceneData = new TypedSceneLoadData<ObjectsPoolsHandler>(_scene);
            var loadResult = await sceneLoader.Load(sceneData);

            var pool = loadResult.Searched;

            pool.CreatePools(builder, loadResult.Scene);

            builder.Register<VfxPool>()
                .As<IVfxPool>()
                .WithParameter<IPoolProvider>(pool);
        }
    }
}