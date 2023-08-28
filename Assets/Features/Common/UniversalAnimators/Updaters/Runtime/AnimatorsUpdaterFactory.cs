using Common.Architecture.DiContainer.Abstract;
using Common.UniversalAnimators.Updaters.Common;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UniversalAnimators.Updaters.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AnimatorsUpdaterRoutes.ServiceName, menuName = AnimatorsUpdaterRoutes.ServicePath)]
    public class AnimatorsUpdaterFactory : ScriptableObject, IGlobalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder, 
            IGlobalCallbacks callbacks)
        {
            builder.Register<AnimatorsUpdater>()
                .As<IAnimatorsUpdater>()
                .AsCallbackListener();
        }
    }
}