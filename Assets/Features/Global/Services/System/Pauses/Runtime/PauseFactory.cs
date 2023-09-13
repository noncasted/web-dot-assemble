using Common.Architecture.DiContainer.Abstract;
using Global.Setup.Service;
using Global.System.Pauses.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.Pauses.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PauseRoutes.ServiceName, menuName = PauseRoutes.ServicePath)]
    public class PauseFactory : ScriptableObject, IGlobalServiceFactory
    {
        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            builder.Register<PauseSwitcher>()
                .As<IPause>();
        }
    }
}