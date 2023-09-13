using Common.Architecture.DiContainer.Abstract;
using Global.Inputs.Common;
using Global.Inputs.Constranits.Storage;
using Global.Inputs.View.Logs;
using Global.Inputs.View.Runtime.Actions;
using Global.Inputs.View.Runtime.Conversion;
using Global.Inputs.View.Runtime.Listeners;
using Global.Inputs.View.Runtime.Mouses;
using Global.Inputs.View.Runtime.Projection;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Inputs.View.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = InputRouter.ServiceName,
        menuName = InputRouter.ServicePath)]
    public class InputViewFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private InputViewLogSettings _logSettings;

        public void Create(IDependencyRegister builder, IGlobalUtils utils)
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