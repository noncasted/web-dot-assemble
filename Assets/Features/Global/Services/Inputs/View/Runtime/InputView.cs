﻿using System;
using Global.Services.Inputs.View.Logs;
using Global.Services.Inputs.View.Runtime.Actions;
using Global.Services.Inputs.View.Runtime.Listeners;
using Global.Services.Setup.Service.Callbacks;
using Global.Services.System.Updaters.Runtime.Abstract;
using UnityEngine.InputSystem;

namespace Global.Services.Inputs.View.Runtime
{
    public class InputView :
        IInputView,
        IInputViewRebindCallbacks,
        IGlobalAwakeListener
    {
        public InputView(
            IInputListenersHandler inputListenersHandler,
            IUpdater updater,
            InputActions inputActions,
            Controls controls,
            InputViewLogger logger)
        {
            _inputListenersHandler = inputListenersHandler;
            _updater = updater;
            _inputActions = inputActions;
            _controls = controls;
            _logger = logger;
        }

        private readonly InputViewLogger _logger;

        private readonly IInputListenersHandler _inputListenersHandler;
        private readonly IUpdater _updater;
        private readonly InputActions _inputActions;
        private readonly Controls _controls;
        
        public event Action DebugConsolePreformed;

        public void OnAwake()
        {
            _controls.Enable();
            _inputListenersHandler.InvokeListen();
            _updater.Add(_inputActions);
        }

        public void OnBeforeRebind()
        {
            _inputListenersHandler.InvokeUnlisten();

            _logger.OnBeforeRebind();
        }

        public void OnAfterRebind()
        {
            _inputListenersHandler.InvokeListen();

            _logger.OnAfterRebind();
        }

        private void OnDebugConsolePreformed(InputAction.CallbackContext context)
        {
            DebugConsolePreformed?.Invoke();
        }
    }
}