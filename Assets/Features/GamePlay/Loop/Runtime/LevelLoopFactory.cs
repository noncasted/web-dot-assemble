using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using GamePlay.Loop.Common;
using GamePlay.Loop.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Loop.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelLoopRoutes.ServiceName,
        menuName = LevelLoopRoutes.ServicePath)]
    public class LevelLoopFactory : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] [Indent] private LevelLoopLogSettings _logSettings;

        public void Create(IServiceCollection builder, ILocalUtils utils)
        {
            builder.Register<LevelLoopLogger>()
                .WithParameter(_logSettings);

            builder.Register<LevelLoop>()
                .AsCallbackListener();
        }
    }
}