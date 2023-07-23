using System;
using Global.Services.Inputs.Constranits.Definition;
using Global.Services.Inputs.Constranits.Storage;
using Global.Services.Inputs.View.Logs;
using Global.Services.Inputs.View.Runtime.Listeners;
using UnityEngine.InputSystem;

namespace Global.Services.Inputs.View.Runtime.Movement
{
    public class RollInputView : IRollInputView, IInputListener
    {
        public RollInputView(
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

        public event Action Performed;
        public event Action Canceled;

        public void Listen()
        {
            _gamePlay.Roll.performed += OnPerformed;
            _gamePlay.Roll.canceled += OnCanceled;
        }

        public void Unlisten()
        {
            _gamePlay.Roll.performed -= OnPerformed;
            _gamePlay.Roll.canceled -= OnCanceled;
        }

        private void OnPerformed(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.RollInput] == true)
            {
                Canceled?.Invoke();

                _logger.OnInputCanceledWithConstraint(InputConstraints.RollInput);
                return;
            }

            _logger.OnRollPressed();

            Performed?.Invoke();
        }

        private void OnCanceled(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.RollInput] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.RollInput);
                return;
            }

            _logger.OnRollCanceled();

            Canceled?.Invoke();
        }
    }
}