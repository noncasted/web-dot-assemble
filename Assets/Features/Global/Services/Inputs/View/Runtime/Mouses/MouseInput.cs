﻿using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Global.Services.Inputs.Constranits.Definition;
using Global.Services.Inputs.Constranits.Storage;
using Global.Services.Inputs.View.Logs;
using Global.Services.Inputs.View.Runtime.Listeners;
using Global.Services.System.Updaters.Runtime.Abstract;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Global.Services.Inputs.View.Runtime.Mouses
{
    public class MouseInput : IInputListener, IUpdatable, IMouseInput
    {
        public MouseInput(
            IInputConstraintsStorage constraintsStorage,
            IInputListenersHandler inputListenersHandler,
            IUpdater updater,
            Controls.GamePlayActions gamePlay,
            InputViewLogger logger)
        {
            _constraintsStorage = constraintsStorage;
            _updater = updater;
            _gamePlay = gamePlay;
            _logger = logger;

            inputListenersHandler.AddListener(this);
        }

        private readonly IInputConstraintsStorage _constraintsStorage;
        private readonly IUpdater _updater;
        private readonly Controls.GamePlayActions _gamePlay;
        private readonly InputViewLogger _logger;

        private Vector2 _position;

        public event Action LeftDown;
        public event Action LeftUp;
        public event Action RightDown;
        public event Action RightUp;

        public Vector2 Position => _position;

        public async UniTask WaitLeftUpAsync(CancellationToken cancellation)
        {
            var completion = new UniTaskCompletionSource();

            cancellation.Register(() =>
            {
                completion.TrySetCanceled();
                LeftUp -= OnLeftUp;
            });

            LeftUp += OnLeftUp;

            void OnLeftUp()
            {
                completion.TrySetResult();
                LeftUp -= OnLeftUp;
            }

            await completion.Task;
        }

        public void Listen()
        {
            _gamePlay.LeftClick.performed += OnLeftMouseButtonDown;
            _gamePlay.LeftClick.canceled += OnLeftMouseButtonUp;
            _gamePlay.RightClick.performed += OnRightMouseButtonDown;
            _gamePlay.RightClick.canceled += OnRightMouseButtonUp;

            _updater.Add(this);
        }

        public void UnListen()
        {
            _gamePlay.LeftClick.performed -= OnLeftMouseButtonDown;
            _gamePlay.LeftClick.canceled -= OnLeftMouseButtonUp;
            _gamePlay.RightClick.performed -= OnRightMouseButtonDown;
            _gamePlay.RightClick.canceled -= OnRightMouseButtonUp;

            _updater.Remove(this);
        }

        private void OnLeftMouseButtonDown(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.Mouse] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.Mouse);
                return;
            }

            _logger.OnLeftMouseButtonDown();

            LeftDown?.Invoke();
        }

        private void OnLeftMouseButtonUp(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.Mouse] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.Mouse);
                return;
            }

            _logger.OnLeftMouseButtonUp();

            LeftUp?.Invoke();
        }

        private void OnRightMouseButtonDown(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.Mouse] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.Mouse);
                return;
            }

            _logger.OnRightMouseButtonDown();

            RightDown?.Invoke();
        }

        private void OnRightMouseButtonUp(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.Mouse] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.Mouse);
                return;
            }

            _logger.OnRightMouseButtonUp();

            RightUp?.Invoke();
        }

        public void OnUpdate(float delta)
        {
            if (Application.isMobilePlatform == true)
            {
                var touches = Input.touches;

                if (touches.Length < 1)
                    return;

                _position = touches[0].rawPosition;
            }
            else
            {
                _position = Mouse.current.position.ReadValue();
            }

            _logger.OnLeftMouseButtonDown();
        }
    }
}