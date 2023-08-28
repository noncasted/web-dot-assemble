using Common.Architecture.DiContainer.Abstract;
using GamePlay.Config.Runtime;
using Global.GameLoops.Common;
using Global.Setup.Service;
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

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            //
            builder.Register<GameLoop>()
                .WithParameter(_level)
                .As<IGameLoop>()
                .AsSelfResolvable();
        }
    }
}