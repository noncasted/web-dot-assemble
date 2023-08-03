using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using GamePlay.Level.Services.AssembleCheck.Common;
using GamePlay.Level.Services.AssembleCheck.Factory;
using UnityEngine;

namespace GamePlay.Level.Services.AssembleCheck.Setup
{
    [CreateAssetMenu(fileName = AssembleCheckRoutes.FactoryName,
        menuName = AssembleCheckRoutes.FactoryPath)]
    public class AssembleCheckSetup : ScriptableObject, ILocalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<AssembleCheckFactory>()
                .As<IAssembleCheckFactory>();
        }
    }
}