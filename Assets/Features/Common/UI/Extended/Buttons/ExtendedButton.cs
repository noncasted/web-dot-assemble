using System;
using UnityEngine;

namespace Common.UI.Extended.Buttons
{
    [DisallowMultipleComponent]
    public class ExtendedButton : MonoBehaviour
    {
        [SerializeField] private ExtendedTriggerReceiver _triggerReceiver;
        [SerializeReference] private IStateHandler[] _stateHandlers;

        public event Action Clicked;
        
        private void OnEnable()
        {
            foreach (var handler in _stateHandlers)
                handler.Construct(_triggerReceiver);

            _triggerReceiver.PointerUp += OnPointerUp;
        }

        private void OnDisable()
        {
            foreach (var handler in _stateHandlers)
                handler.Dispose();
            
            _triggerReceiver.PointerUp -= OnPointerUp;
        }

        private void OnPointerUp()
        {
            Clicked?.Invoke();
        }
    }
}