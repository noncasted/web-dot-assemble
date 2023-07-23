using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using GamePlay.Loop.Common;
using GamePlay.Loop.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Loop.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelLoopRoutes.ServiceName,
        menuName = LevelLoopRoutes.ServicePath)]
    public class LevelLoopAsset : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] [Indent] private LevelLoopLogSettings _logSettings;

        public void Create(IDependencyRegister builder, ILocalServiceBinder serviceBinder, IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<LevelLoopLogger>()
                .WithParameter(_logSettings);

            builder.Register<LevelLoop>()
                .AsCallbackListener();
        }
    }
}