using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Common.Architecture.ObjectsPools.Runtime;
using Common.Architecture.ObjectsPools.Runtime.Abstract;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.Services.VfxPools.Common;
using Internal.Services.Scenes.Abstract;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.VfxPools.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = VfxPoolRoutes.ServiceName, menuName = VfxPoolRoutes.ServicePath)]
    public class VfxPoolFactory : ScriptableObject, ILocalServiceAsyncFactory
    {
        [SerializeField] [NestedScriptableObjectField] private SceneData _scene;

        public async UniTask Create(IServiceCollection builder,ISceneLoader sceneLoader, ILocalUtils utils)
        {
            var loadResult = await sceneLoader.LoadTyped<ObjectsPoolsHandler>(_scene);

            var pool = loadResult.Searched;

            pool.CreatePools(builder, loadResult.Scene);

            builder.Register<VfxPool>()
                .As<IVfxPool>()
                .WithParameter<IPoolProvider>(pool);
        }
    }
}