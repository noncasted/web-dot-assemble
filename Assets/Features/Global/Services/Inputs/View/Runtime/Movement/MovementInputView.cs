using System;
using Global.Services.Inputs.Constranits.Definition;
using Global.Services.Inputs.Constranits.Storage;
using Global.Services.Inputs.View.Logs;
using Global.Services.Inputs.View.Runtime.Listeners;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Global.Services.Inputs.View.Runtime.Movement
{
    public class MovementInputView : IMovementInputView, IInputListener
    {
        public MovementInputView(
            IInputConstraintsStorage constraintsStorage,
            IInputListenersHandler inputListenersHandler,
            Controls.GamePlayActions gamePlay,
            InputViewLogger logger)
        {
            _constraintsStorage = constraintsStorage;
            _gamePlay = gamePlay;
            _logger = logger;
            
            inputListenersHandler.AddListener(this);
        }

        private readonly IInputConstraintsStorage _constraintsStorage;
        private readonly Controls.GamePlayActions _gamePlay;
        private readonly InputViewLogger _logger;

        public event Action<Vector2> MovementPerformed;
        public event Action MovementCanceled;
        
        public void Listen()
        {
            _gamePlay.Movement.performed += OnMovementPerformed;
            _gamePlay.Movement.canceled += OnMovementCanceled;
        }

        public void Unlisten()
        {
            _gamePlay.Movement.performed -= OnMovementPerformed;
            _gamePlay.Movement.canceled -= OnMovementCanceled;
        }

        private void OnMovementPerformed(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.MovementInput] == true)
            {
                MovementCanceled?.Invoke();

                _logger.OnInputCanceledWithConstraint(InputConstraints.MovementInput);
                return;
            }

            var value = context.ReadValue<Vector2>();

            _logger.OnMovementPressed(value);

            MovementPerformed?.Invoke(value);
        }

        private void OnMovementCanceled(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.MovementInput] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.MovementInput);
                return;
            }

            _logger.OnMovementCanceled();

            MovementCanceled?.Invoke();
        }
    }
}