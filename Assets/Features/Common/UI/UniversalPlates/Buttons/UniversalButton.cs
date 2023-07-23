using System;
using Common.UI.UniversalPlates.Runtime;
using Common.UI.UniversalPlates.Runtime.Switches;
using UnityEngine;

namespace Common.UI.UniversalPlates.Buttons
{
    [DisallowMultipleComponent]
    public class UniversalButton : MonoBehaviour
    {
        [SerializeField] private UniversalButtonConfig _config;
        [SerializeField] private UniversalButtonHandler _handler;
        [SerializeField] private UniversalPlate _plate;
        [SerializeReference] private IColorSwitchTarget[] _targets;

        private float _time;
        private bool _isActive;

        public event Action Clicked;

        private void Awake()
        {
            foreach (var target in _targets)
                target.Init();

            _time = float.MaxValue;
        }

        private void OnEnable()
        {
            _handler.Pressed += OnPressed;
            _handler.Released += OnReleased;
        }

        private void OnDisable()
        {
            _handler.Pressed -= OnPressed;
            _handler.Released -= OnReleased;

            _isActive = false;
            _time = 0f;
            _plate.Unlock();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnPressed()
        {
            _isActive = true;
            _plate.Lock();

            _time = 0f;
        }

        private void OnReleased()
        {
            _time = 0f;

            Clicked?.Invoke();
        }

        private void Update()
        {
            if (_isActive == false)
                return;

            var progress = _time / _config.SwitchTime;

            if (_handler.IsPressed == true)
            {
                foreach (var target in _targets)
                    target.ToActive(progress);
            }
            else
            {
                foreach (var target in _targets)
                    target.ToBase(progress);
            }

            if (_time >= 1f)
            {
                _isActive = false;
                _plate.Unlock();
            }
            
            _time += Time.deltaTime;
        }
    }
}