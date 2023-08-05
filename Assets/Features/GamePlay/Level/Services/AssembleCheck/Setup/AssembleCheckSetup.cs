using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using GamePlay.Level.Services.AssembleCheck.Common;
using GamePlay.Level.Services.AssembleCheck.Factory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.Services.AssembleCheck.Setup
{
    [InlineEditor]
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