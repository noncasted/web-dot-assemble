using Common.UI.UniversalPlates.Runtime;
using Common.UI.UniversalPlates.Runtime.Plate.Hover;
using Common.UI.UniversalPlates.Runtime.Switches;
using UnityEngine;

namespace Common.UI.UniversalPlates.Extended.Texts
{
    public class AnimatedText : IPlateFeature
    {
        [SerializeField] private AnimatedTextConfig _config;

        [SerializeReference] private IColorSwitchTarget[] _targets;

        [SerializeField] private HoverTrigger _trigger;

        public bool IsUpdatable => true;

        private float _progress;
        private bool _isHovered;

        public void Init()
        {
            foreach (var target in _targets)
                target.Init();

            _progress = 1f;
        }

        public void Disable()
        {
            _progress = 1f;
            _isHovered = false;

            foreach (var target in _targets)
                target.ToBase(1f);
        }

        public void OnLocked()
        {
            _progress = 1f;
            _isHovered = false;
        }

        public void Update()
        {
            var delta = Time.deltaTime * (1f / _config.SwitchTime);

            if (_trigger.IsHovered != _isHovered)
                _progress = 0f;

            _progress += delta;
            _progress = Mathf.Clamp01(_progress);

            if (_trigger.IsHovered == true)
            {
                _isHovered = true;

                foreach (var target in _targets)
                    target.ToActive(_progress);
            }
            else
            {
                _isHovered = false;

                foreach (var target in _targets)
                    target.ToBase(_progress);
            }
        }
    }
}