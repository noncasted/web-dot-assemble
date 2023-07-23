using Common.Architecture.DiContainer.Abstract;
using Global.Services.Setup.Service;
using Global.Services.System.Pauses.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.System.Pauses.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PauseRoutes.ServiceName, menuName = PauseRoutes.ServicePath)]
    public class PauseAsset : ScriptableObject, IGlobalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<PauseSwitcher>()
                .As<IPause>();
        }
    }
}