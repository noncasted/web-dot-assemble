using Common.Architecture.Local.ComposedSceneConfig;
using Common.Architecture.Local.Services.Abstract;
using Menu.Loop.Runtime;
using Menu.Main.Common;
using Menu.Main.Controller.Runtime;
using Menu.Main.UI.Runtime;
using Menu.Services.Cameras.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace Menu.Config.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "MenuConfig", menuName = MenuAssetsPaths.Root + "Config")]
    public class MenuConfig : ComposedSceneAsset
    {
        [FoldoutGroup("Common")] [SerializeField] private BaseMenuLoopFactory _menuLoop;
        [FoldoutGroup("Common")] [SerializeField] private MenuCameraFactory _camera;
        
        [FoldoutGroup("Main")] [SerializeField] private MenuControllerFactory _menuController;
        [FoldoutGroup("Main")] [SerializeField] private BaseMenuUiFactory _menuUI;

        [SerializeField] private MenuScope _scope;
        
        protected override ILocalServiceFactory[] GetFactories()
        {
            return new ILocalServiceFactory[]
            {
                _menuLoop,
                _camera,
                _menuController,
            };
        }

        protected override ILocalServiceAsyncFactory[] GetAsyncFactories()
        {
            return new ILocalServiceAsyncFactory[]
            {
                _menuUI,
            };
        }

        protected override LifetimeScope AssignScope()
        {
            return _scope;
        }
    }
}