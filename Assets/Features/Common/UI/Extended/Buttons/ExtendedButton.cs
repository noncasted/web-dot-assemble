using System;
using UnityEngine;

namespace Common.UI.Extended.Buttons
{
    [DisallowMultipleComponent]
    public class ExtendedButton : MonoBehaviour
    {
        [SerializeField] private ExtendedTriggerReceiver _triggerReceiver;
        [SerializeReference] private IButtonState[] _stateHandlers;

        private readonly ButtonEvents _events = new();
        private readonly ButtonStateHandler _stateHandler = new();
        
        public event Action Clicked;
        
        private void OnEnable()
        {
            var utils = new ButtonUtils(_triggerReceiver, _stateHandler);
            
            foreach (var handler in _stateHandlers)
                handler.Construct(utils);

            _triggerReceiver.PointerUp += OnPointerUp;
            _triggerReceiver.PointerDown += _events.InvokePointerDown;
            _triggerReceiver.PointerEnter += _events.InvokePointerEnter;
            _triggerReceiver.PointerExit += _events.InvokePointerExit;
        }

        private void OnDisable()
        {
            foreach (var handler in _stateHandlers)
                handler.Dispose();
            
            _triggerReceiver.PointerUp -= OnPointerUp;
            _triggerReceiver.PointerDown -= _events.InvokePointerDown;
            _triggerReceiver.PointerEnter -= _events.InvokePointerEnter;
            _triggerReceiver.PointerExit -= _events.InvokePointerExit;
        }

        private void Update()
        {
            _events.InvokeUpdate();
        }

        private void OnPointerUp()
        {
            _events.InvokePointerUp();
            Clicked?.Invoke();
        }
    }
}