using Common.Architecture.DiContainer.Abstract;
using GamePlay.Config.Runtime;
using Global.GameLoops.Common;
using Global.Setup.Service;
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
        [SerializeField] private MenuConfig _menu;
        [SerializeField] private LevelConfig _level;

        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            builder.Register<GameLoop>()
                .WithParameter(_level)
                .WithParameter(_menu)
                .As<IGameLoop>()
                .AsSelfResolvable();
        }
    }
}