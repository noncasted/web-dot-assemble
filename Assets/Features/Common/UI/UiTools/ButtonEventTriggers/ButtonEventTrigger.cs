﻿using Global.System.MessageBrokers.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.UI.UiTools.ButtonEventTriggers
{
    public class ButtonEventTrigger :
        MonoBehaviour,
        IPointerEnterHandler,
        IPointerExitHandler,
        IPointerDownHandler,
        IPointerUpHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Msg.Publish(new ButtonClickEvent());
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Msg.Publish(new ButtonTouchEvent());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }

        public void OnPointerUp(PointerEventData eventData)
        {
        }
    }
}