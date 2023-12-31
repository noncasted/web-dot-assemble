﻿using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
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
        public override async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var linker = FindFirstObjectByType<MenuUiLinker>();
            
            for (var i = 0; i < linker.Root.childCount; i++)
                linker.Root.GetChild(i).gameObject.SetActive(true);
            
            services.RegisterInstance(linker.Achievements);
            services.RegisterInstance(linker.Collections);
            services.RegisterInstance(linker.Leaderboards);
            services.RegisterInstance(linker.Main);
            services.RegisterInstance(linker.Quests);
            services.RegisterInstance(linker.Settings);
            services.RegisterInstance(linker.ShopView);
            services.RegisterInstance(linker.Calendar);
            services.RegisterInstance(linker.TabTransitionPoints);

            var navigations = FindObjectsByType<TabNavigation>(FindObjectsSortMode.None);

            foreach (var navigation in navigations)
                services.Inject(navigation);
        }
    }
}