using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.UI.Common;
using GamePlay.UI.Runtime.Score;
using Global.Scenes.Operations.Abstract;
using Global.Scenes.Operations.Data;
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
        
        public async UniTask Create(IDependencyRegister builder,ISceneLoader sceneLoader, ILocalUtils utils)
        {
            var sceneData = await sceneLoader.LoadTyped<LevelUiLinker>(_scene);
            var linker = sceneData.Searched;
            
            builder.Register<ScoreController>()
                .WithParameter<IScoreView>(linker.Score)
                .As<IScoreController>()
                .AsCallbackListener();
        }
    }
}