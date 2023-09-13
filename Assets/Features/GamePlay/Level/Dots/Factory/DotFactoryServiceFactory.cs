using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using GamePlay.Level.Dots.Common;
using GamePlay.Level.Dots.Destroyer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.Dots.Factory
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DotsRoutes.FactoryName,
        menuName = DotsRoutes.FactoryPath)]
    public class DotFactoryServiceFactory : ScriptableObject, ILocalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<DotFactory>()
                .As<IDotFactory>();

            builder.Register<DotDestroyer>()
                .As<IDotDestroyer>();
        }
    }
}