using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.UI.Common;
using GamePlay.UI.Runtime.Score;
using Internal.Services.Scenes.Abstract;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.UI.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelUIRoutes.ServiceName,
        menuName = LevelUIRoutes.ServicePath)]
    public class LevelUiFactory : ScriptableObject, ILocalServiceAsyncFactory
    {
        [SerializeField] [NestedScriptableObjectField] private SceneData _scene;
        
        public async UniTask Create(IServiceCollection builder,ISceneLoader sceneLoader, ILocalUtils utils)
        {
            var loadResult = await sceneLoader.LoadTyped<LevelUiView>(_scene);
            var view = loadResult.Searched;
            
            builder.Register<LevelUiController>()
                .WithParameter<ILevelUiView>(view)
                .As<ILevelUiController>()
                .AsCallbackListener();
        }
    }
}