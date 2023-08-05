﻿using Common.Architecture.DiContainer.Abstract;
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
    [CreateAssetMenu(fileName = UiRootRoutes.ServiceName,
        menuName = UiRootRoutes.ServicePath)]
    public class UiRootFactory : ScriptableObject, ILocalServiceAsyncFactory
    {
        [SerializeField] [Scene] private string _scene;
        
        public async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            IEventLoopsRegistry callbacks)
        {
            var loadData = new TypedSceneLoadData<MenuUiLinker>(_scene);
            var sceneData = await sceneLoader.Load(loadData);
            var linker = sceneData.Searched;

            builder.RegisterInstance(linker.Achievements);
            builder.RegisterInstance(linker.AvatarCollections);
            builder.RegisterInstance(linker.Leaderboards);
            builder.RegisterInstance(linker.Main);
            builder.RegisterInstance(linker.Quests);
            builder.RegisterInstance(linker.Settings);
            builder.RegisterInstance(linker.ShopView);
        }
    }
}