using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.Services.Background.Common;
using Global.Scenes.ScenesFlow.Handling.Data;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using NaughtyAttributes;
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

        public async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            IEventLoopsRegistry callbacks)
        {
            var sceneData = new TypedSceneLoadData<GameBackground>(_scene);
            var result = await sceneLoader.Load(sceneData);

            var background = result.Searched;

            builder.RegisterComponent(background)
                .As<IGameBackground>()
                .AsCallbackListener();
        }
    }
}