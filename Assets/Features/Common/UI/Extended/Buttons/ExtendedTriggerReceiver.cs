using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.UI.Extended.Buttons
{
    public class ExtendedTriggerReceiver :
        MonoBehaviour, 
        IPointerEnterHandler,
        IPointerExitHandler,
        IPointerDownHandler,
        IPointerUpHandler,
        ITriggerReceiver
    {
        public event Action PointerEnter;
        public event Action PointerExit;
        public event Action PointerDown;
        public event Action PointerUp;

        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerEnter?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PointerExit?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            PointerDown?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            PointerUp?.Invoke();
        }
    }
}