using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Menu.Achievements.UI
{
    [DisallowMultipleComponent]
    public class AchievementEntryViewEventsReceiver : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action Down;
        public event Action Up;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            Down?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Up?.Invoke();
        }
    }
}