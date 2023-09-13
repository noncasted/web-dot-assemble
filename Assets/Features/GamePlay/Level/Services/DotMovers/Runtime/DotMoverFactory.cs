using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using GamePlay.Level.Services.DotMovers.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.Services.DotMovers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DotMoverRoutes.ServiceName,
        menuName = DotMoverRoutes.ServicePath)]
    public class DotMoverFactory : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] private DotMoverConfig _config;
        
        public void Create(IDependencyRegister builder, ILocalUtils utils)
        {
            builder.Register<DotMover>()
                .WithParameter<IDotMoverConfig>(_config)
                .As<IDotMover>();
        }
    }
}