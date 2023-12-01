using Common.UI.Buttons;
using Common.UI.Buttons.Events;
using UnityEngine;

namespace Menu.Main.UI.DotSelections
{
    [DisallowMultipleComponent]
    public class DotSelectionMenuEntry :
        ButtonState,
        IPointerEnterListener,
        IPointerExitListener,
        IPointerDownListener,
        IPointerUpListener,
        IButtonUpdatable
    {
        [SerializeField] private ExtendedButton _button;
        
        [SerializeField] private float _switchTime = 0.2f;
        [SerializeField] private float _selectedScale = 1.1f;
        [SerializeField] private float _pressedScale = 1f;

        private Vector3 _targetScale;
        private Vector3 _startScale;
        private float _currentTime;

        public ExtendedButton Button => _button;

        public override void Construct(IButtonUtils utils)
        {
        }

        public override void Dispose()
        {
        }

        public void Construct()
        {
            
        }

        public void UpdateState(float delta)
        {
            _currentTime += delta;
            var progress = _currentTime / _switchTime;

            if (progress > 1f)
                return;

            transform.localScale = Vector3.Lerp(_startScale, _targetScale, progress);
        }

        public void OnPointerEnter()
        {
            _currentTime = 0f;
            _startScale = transform.localScale;
            _targetScale = Vector3.one * _selectedScale;
        }

        public void OnPointerExit()
        {
            _currentTime = 0f;
            _startScale = transform.localScale;
            _targetScale = Vector3.one;
        }

        public void OnPointerDown()
        {
            _currentTime = 0f;
            _startScale = transform.localScale;
            _targetScale = Vector3.one * _pressedScale;
        }

        public void OnPointerUp()
        {
            _currentTime = 0f;
            _startScale = transform.localScale;
            _targetScale = Vector3.one * _selectedScale;
        }
    }
}