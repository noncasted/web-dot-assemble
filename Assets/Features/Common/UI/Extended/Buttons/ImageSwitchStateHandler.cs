using System;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI.Extended.Buttons
{
    [Serializable]
    public class ImageSwitchStateHandler : IStateHandler
    {
        [SerializeField] private Image _image;

        [SerializeField] private Sprite _entered;
        [SerializeField] private Sprite _exited;
        
        private ITriggerReceiver _triggerReceiver;

        public void Construct(ITriggerReceiver triggerReceiver)
        {
            _triggerReceiver = triggerReceiver;

            _triggerReceiver.PointerEnter += OnPointerEnter;
            _triggerReceiver.PointerExit += OnPointerExit;
            
            OnPointerExit();
        }

        public void Dispose()
        {
            _triggerReceiver.PointerEnter -= OnPointerEnter;
            _triggerReceiver.PointerExit -= OnPointerExit;
        }

        private void OnPointerEnter()
        {
            _image.sprite = _entered;
        }

        private void OnPointerExit()
        {
            _image.sprite = _exited;
        }
    }
}