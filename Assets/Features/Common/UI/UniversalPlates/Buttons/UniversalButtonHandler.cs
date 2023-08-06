using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.UI.UniversalPlates.Buttons
{
    [DisallowMultipleComponent]
    public class UniversalButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action Pressed;
        public event Action Released;

        public bool IsPressed { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsPressed = true;
            
            Pressed?.Invoke();
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            IsPressed = false;
            
            Released?.Invoke();
        }
    }
}