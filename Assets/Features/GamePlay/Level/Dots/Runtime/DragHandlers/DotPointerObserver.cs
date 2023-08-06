using System;
using UnityEngine;

namespace GamePlay.Level.Dots.Runtime.DragHandlers
{
    [DisallowMultipleComponent]
    public class DotPointerObserver : MonoBehaviour, IDotPointerObserver
    {
        public event Action Dragged;
        public event Action Dropped;

        private void OnMouseDown()
        {
            Dragged?.Invoke();
        }

        private void OnMouseUp()
        {
            Dropped?.Invoke();
        }
    }
}