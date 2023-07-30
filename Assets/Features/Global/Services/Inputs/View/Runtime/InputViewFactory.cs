using Common.Architecture.DiContainer.Abstract;
using Global.Services.Inputs.Common;
using Global.Services.Inputs.Constranits.Storage;
using Global.Services.Inputs.View.Logs;
using Global.Services.Inputs.View.Runtime.Actions;
using Global.Services.Inputs.View.Runtime.Conversion;
using Global.Services.Inputs.View.Runtime.Listeners;
using Global.Services.Inputs.View.Runtime.Mouses;
using Global.Services.Inputs.View.Runtime.Projection;
using Global.Services.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Inputs.View.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = InputRouter.ServiceName,
        menuName = InputRouter.ServicePath)]
    public class InputViewFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private InputViewLogSettings _logSettings;

        public void Create(IDependencyRegister builder, IGlobalServiceBinder serviceBinder, IGlobalCallbacks callbacks)
        {
            var controls = new Controls();
            var gamePlay = controls.GamePlay;

            builder.Register<MouseInput>()
                .WithParameter(gamePlay)
                .As<IMouseInput>()
                .AsSelfResolvable();

            builder.Register<InputViewLogger>()
                .WithParameter(_logSettings);

            builder.Register<InputConversion>()
                .As<IInputConversion>();

            builder.Register<InputProjection>()
                .As<IInputProjection>();

            builder.Register<InputView>()
                .WithParameter(controls)
                .AsImplementedInterfaces()
                .AsCallbackListener();

            builder.Register<InputActions>()
                .As<IInputActions>()
                .AsSelf()
                .AsSelfResolvable();

            builder.Register<InputListenersHandler>()
                .As<IInputListenersHandler>();

            builder.Register<InputConstraintsStorage>()
                .As<IInputConstraintsStorage>();
        }
    }
}