using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
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
        public void Create(IDependencyRegister builder, ILocalServiceBinder serviceBinder, IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<DotMover>()
                .As<IDotMover>();
        }
    }
}