using Common.Architecture.DiContainer.Abstract;
using Global.Services.Inputs.Common;
using Global.Services.Inputs.Constranits.Storage;
using Global.Services.Inputs.View.Logs;
using Global.Services.Inputs.View.Runtime.Actions;
using Global.Services.Inputs.View.Runtime.Combat;
using Global.Services.Inputs.View.Runtime.Conversion;
using Global.Services.Inputs.View.Runtime.Listeners;
using Global.Services.Inputs.View.Runtime.Movement;
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
            var debug = controls.Debug;
            
            builder.Register<InputViewLogger>()
                .WithParameter(_logSettings);

            builder.Register<CombatInput>()
                .As<ICombatInput>()
                .WithParameter(gamePlay)
                .AsSelfResolvable();

            builder.Register<InputConversion>()
                .As<IInputConversion>();

            builder.Register<MovementInputView>()
                .As<IMovementInputView>()
                .WithParameter(gamePlay)
                .AsSelfResolvable();

            builder.Register<RollInputView>()
                .As<IRollInputView>()
                .WithParameter(gamePlay)
                .AsSelfResolvable();

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