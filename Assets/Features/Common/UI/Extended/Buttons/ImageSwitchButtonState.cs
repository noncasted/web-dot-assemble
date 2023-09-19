using System;
using Common.UI.Extended.Buttons.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI.Extended.Buttons
{
    [Serializable]
    public class ImageSwitchButtonState : IButtonState, IPointerEnterListener, IPointerExitListener
    {
        [SerializeField] private Image _image;

        [SerializeField] private Sprite _entered;
        [SerializeField] private Sprite _exited;
        
        public void Construct(IButtonUtils utils)
        {
            OnPointerExit();
        }

        public void Dispose()
        {
        }

        public void OnPointerEnter()
        {
            _image.sprite = _entered;
        }

        public void OnPointerExit()
        {
            _image.sprite = _exited;
        }
    }
}