using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Cysharp.Threading.Tasks;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using Menu.Common.Navigation;
using Menu.UiRoot.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.UiRoot.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = UiRootRoutes.MockName,
        menuName = UiRootRoutes.MockPath)]
    public class UiRootMockFactory : BaseUiRootFactory
    {
        public override async UniTask Create(IDependencyRegister builder,ISceneLoader sceneLoader, ILocalUtils utils)
        {
            var linker = FindFirstObjectByType<MenuUiLinker>();
            
            for (var i = 0; i < linker.Root.childCount; i++)
                linker.Root.GetChild(i).gameObject.SetActive(true);
            
            builder.RegisterInstance(linker.Achievements);
            builder.RegisterInstance(linker.Collections);
            builder.RegisterInstance(linker.Leaderboards);
            builder.RegisterInstance(linker.Main);
            builder.RegisterInstance(linker.Quests);
            builder.RegisterInstance(linker.Settings);
            builder.RegisterInstance(linker.ShopView);
            builder.RegisterInstance(linker.Calendar);
            builder.RegisterInstance(linker.TabTransitionPoints);

            var navigations = FindObjectsByType<TabNavigation>(FindObjectsSortMode.None);

            foreach (var navigation in navigations)
                builder.Inject(navigation);
        }
    }
}