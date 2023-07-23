using System;
using Global.Services.Inputs.Constranits.Definition;
using Global.Services.Inputs.Constranits.Storage;
using Global.Services.Inputs.View.Logs;
using Global.Services.Inputs.View.Runtime.Actions;
using Global.Services.Inputs.View.Runtime.Listeners;
using UnityEngine.InputSystem;

namespace Global.Services.Inputs.View.Runtime.Combat
{
    public class CombatInput : ICombatInput, IInputListener
    {
        public CombatInput(
            IInputConstraintsStorage constraintsStorage,
            IInputActions actions,
            IInputListenersHandler listenersHandler,
            Controls.GamePlayActions gamePlay,
            InputViewLogger logger)
        {
            _constraintsStorage = constraintsStorage;
            _actions = actions;
            _gamePlay = gamePlay;
            _logger = logger;

            listenersHandler.AddListener(this);
        }
        
        private readonly IInputConstraintsStorage _constraintsStorage;
        private readonly IInputActions _actions;
        private readonly Controls.GamePlayActions _gamePlay;
        private readonly InputViewLogger _logger;
        
        public event Action RangeAttackPerformed;
        public event Action RangeAttackCanceled;
        public event Action MeleeAttackPerformed;
        public event Action MeleeAttackCanceled;
        
        public void Listen()
        {
            _gamePlay.RangeAttack.performed += OnRangeAttackPerformed;
            _gamePlay.RangeAttack.canceled += OnRangeAttackCanceled;
            
            _gamePlay.MeleeAttack.performed += OnMeleeAttackPerformed;
            _gamePlay.MeleeAttack.canceled += OnMeleeAttackCanceled;
        }

        public void Unlisten()
        {
            _gamePlay.RangeAttack.performed -= OnRangeAttackPerformed;
            _gamePlay.RangeAttack.canceled -= OnRangeAttackCanceled;
            
            _gamePlay.MeleeAttack.performed -= OnMeleeAttackPerformed;
            _gamePlay.MeleeAttack.canceled -= OnMeleeAttackCanceled;
        }
        
        private void OnRangeAttackPerformed(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.AttackInput] == true)
            {
                RangeAttackCanceled?.Invoke();

                _logger.OnInputCanceledWithConstraint(InputConstraints.AttackInput);
                return;
            }
            
            _logger.OnRangeAttackPerformed();

            _actions.Add(InvokeRangePerformed);
        }

        private void OnRangeAttackCanceled(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.AttackInput] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.AttackInput);
                return;
            }

            _logger.OnRangeAttackCanceled();

            _actions.Add(InvokeRangeCanceled);
        }

        private void InvokeRangePerformed()
        {
            RangeAttackPerformed?.Invoke();
        }
        
        private void InvokeRangeCanceled()
        {
            RangeAttackCanceled?.Invoke();
        }
        
        private void OnMeleeAttackPerformed(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.MeleeInput] == true)
            {
                MeleeAttackCanceled?.Invoke();

                _logger.OnInputCanceledWithConstraint(InputConstraints.MeleeInput);
                return;
            }
            
            _logger.OnMeleeAttackPerformed();

            _actions.Add(InvokeMeleePerformed);
        }

        private void OnMeleeAttackCanceled(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.MeleeInput] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.MeleeInput);
                return;
            }

            _logger.OnMeleeAttackCanceled();

            _actions.Add(InvokeMeleeCanceled);
        }

        private void InvokeMeleePerformed()
        {
            MeleeAttackPerformed?.Invoke();
        }
        
        private void InvokeMeleeCanceled()
        {
            MeleeAttackCanceled?.Invoke();
        }
    }
}