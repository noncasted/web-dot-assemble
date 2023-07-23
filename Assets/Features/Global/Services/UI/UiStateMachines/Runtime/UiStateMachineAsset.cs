using Common.Architecture.DiContainer.Abstract;
using Global.Services.Setup.Service;
using Global.Services.UI.UiStateMachines.Common;
using Global.Services.UI.UiStateMachines.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.UI.UiStateMachines.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = UiStateMachineRouter.ServiceName,
        menuName = UiStateMachineRouter.ServicePath)]
    public class UiStateMachineAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private UiStateMachineLogSettings _logSettings;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<UiStateMachineLogger>()
                .WithParameter(_logSettings);

            builder.Register<UiStateMachine>()
                .As<IUiStateMachine>();
        }
    }
}