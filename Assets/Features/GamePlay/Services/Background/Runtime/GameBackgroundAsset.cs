using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.Services.Background.Common;
using Internal.Services.Scenes.Abstract;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.Background.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BackgroundRoutes.ServiceName,
        menuName = BackgroundRoutes.ServicePath)]
    public class GameBackgroundAsset : ScriptableObject, ILocalServiceAsyncFactory
    {
        [SerializeField] [NestedScriptableObjectField] private SceneData _scene;

        public async UniTask Create(IServiceCollection builder,ISceneLoader sceneLoader, ILocalUtils utils)
        {
            var result = await sceneLoader.LoadTyped<GameBackground>(_scene);

            var background = result.Searched;

            builder.RegisterComponent(background)
                .As<IGameBackground>()
                .AsCallbackListener();
        }
    }
}