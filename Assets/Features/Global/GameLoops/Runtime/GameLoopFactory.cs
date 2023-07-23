using Common.Architecture.DiContainer.Abstract;
using GamePlay.Config.Runtime;
using Global.GameLoops.Common;
using Global.Services.Setup.Service;
using Menu.Config.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.GameLoops.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GameLoopRouter.ServiceName,
        menuName = GameLoopRouter.ServicePath)]
    public class GameLoopFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] private LevelConfig _level;
        [SerializeField] private MenuConfig _menu;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<GameLoop>()
                .WithParameter(_level)
                .WithParameter(_menu)
                .As<IGameLoop>()
                .AsSelfResolvable();
        }
    }
}