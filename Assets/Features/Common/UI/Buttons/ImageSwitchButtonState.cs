using System;
using Common.UI.Buttons.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI.Buttons
{
    [Serializable]
    public class ImageSwitchButtonState : 
        ButtonState,
        IPointerEnterListener,
        IPointerExitListener,
        IPointerDownListener,
        IPointerUpListener
    {
        [SerializeField] private Image _image;

        [SerializeField] private Sprite _idle;
        [SerializeField] private Sprite _pressed;
        [SerializeField] private Sprite _selected;
        
        public override void Construct(IButtonUtils utils)
        {
            OnPointerExit();
        }
        
        public override void Dispose()
        {
        }

        public void OnPointerEnter()
        {
            _image.sprite = _selected;
        }

        public void OnPointerExit()
        {
            _image.sprite = _idle;
        }

        public void OnPointerDown()
        {
            _image.sprite = _pressed;
        }

        public void OnPointerUp()
        {
            _image.sprite = _selected;
        }
    }
}