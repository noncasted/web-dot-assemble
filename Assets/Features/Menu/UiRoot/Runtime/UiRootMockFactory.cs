using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using Global.Services.Scenes.ScenesFlow.Handling.Data;
using Global.Services.Scenes.ScenesFlow.Runtime.Abstract;
using Menu.UiRoot.Common;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.UiRoot.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = UiRootRoutes.MockName,
        menuName = UiRootRoutes.MockPath)]
    public class UiRootMockFactory : BaseUiRootFactory
    {
        [SerializeField] [Scene] private string _scene;
        
        public override async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            IEventLoopsRegistry callbacks)
        {
            var linker = FindFirstObjectByType<MenuUiLinker>();
            
            builder.RegisterInstance(linker.Achievements);
            builder.RegisterInstance(linker.AvatarCollections);
            builder.RegisterInstance(linker.Leaderboards);
            builder.RegisterInstance(linker.Main);
            builder.RegisterInstance(linker.Quests);
            builder.RegisterInstance(linker.Settings);
            builder.RegisterInstance(linker.ShopView);
            builder.RegisterInstance(linker.TabTransitionPoints);
        }
    }
}