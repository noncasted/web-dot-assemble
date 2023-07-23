using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using Global.Services.Scenes.ScenesFlow.Handling.Data;
using Global.Services.Scenes.ScenesFlow.Runtime.Abstract;
using Menu.Main.UI.Common;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Main.UI.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuUIRoutes.ServiceName,
        menuName = MenuUIRoutes.ServicePath)]
    public class MenuUiFactory :  BaseMenuUiFactory
    {
        [SerializeField] [Scene] private string _scene;

        public override async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            IEventLoopsRegistry callbacks)
        {
            var sceneData = new TypedSceneLoadData<MenuView>(_scene);
            var scene = await sceneLoader.Load(sceneData);

            var ui = scene.Searched;

            builder.RegisterComponent(ui)
                .As<IMenuView>();
        }
    }
}