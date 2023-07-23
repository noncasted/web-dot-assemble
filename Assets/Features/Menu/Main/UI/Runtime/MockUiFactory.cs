using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using Global.Services.Scenes.ScenesFlow.Runtime.Abstract;
using Menu.Main.UI.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Main.UI.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuUIRoutes.MockName,
        menuName = MenuUIRoutes.MockPath)]
    public class MockUiFactory : BaseMenuUiFactory
    {
        public override async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            IEventLoopsRegistry callbacks)
        {
            var ui = FindObjectOfType<MenuView>();

            builder.RegisterComponent(ui)
                .As<IMenuView>();
        }
    }
}