using System.Collections.Generic;
using Common.Architecture.DiContainer.Abstract;
using Common.Serialization.ScriptableRegistries;
using Global.LevelConfigurations.Common;
using Global.LevelConfigurations.Definition;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.LevelConfigurations.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelConfigurationRoutes.ServiceName,
        menuName = LevelConfigurationRoutes.ServicePath)]
    public class LevelConfigurationFactory : ScriptableRegistry<LevelConfiguration>, IGlobalServiceFactory
    {
        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            var configurations = Objects as IReadOnlyList<ILevelConfiguration>;
            builder.Register<LevelConfigurationProvider>()
                .WithParameter(configurations)
                .As<ILevelConfigurationProvider>();
        }
    }
}