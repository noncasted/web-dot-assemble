using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.Level.Dots.Runtime.DragHandlers
{
    [DisallowMultipleComponent]
    public class DotPointerObserver : MonoBehaviour, IDotPointerObserver, IPointerDownHandler, IPointerUpHandler
    {
        public event Action Dragged;
        public event Action Dropped;

        public void OnPointerDown(PointerEventData eventData)
        {
            Dragged?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Dropped?.Invoke();
        }
    }
}