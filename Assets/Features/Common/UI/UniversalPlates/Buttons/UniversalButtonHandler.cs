using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.UI.UniversalPlates.Buttons
{
    [DisallowMultipleComponent]
    public class UniversalButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool _isPressed;

        public event Action Pressed;
        public event Action Released;

        public bool IsPressed => _isPressed;    
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
            
            Pressed?.Invoke();
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
            
            Released?.Invoke();
        }
    }
}