using System;
using Common.UI.UniversalPlates.Setup;
using MPUIKIT;
using UnityEngine;

namespace Common.UI.UniversalPlates.Runtime.Plate
{
    [Serializable]
    public class PlateColorSetter : IPlateFeature
    {
        [SerializeField] private UniversalColor _color;
        [SerializeField] private UniversalPlateBrightnessConfig _brightness;

        [SerializeField] private MPImage _target;
        
        public bool IsUpdatable => false;

        public void Init()
        {
            
        }

        public void Disable()
        {
            
        }

        public void OnLocked()
        {
            
        }

        public void Update()
        {
            if (_target == null
                || _brightness == null)
                return;

            var baseColor = _color.Value;
            var brightness = _brightness.Value;

            var plateColor = new Color(
                baseColor.r * brightness,
                baseColor.g * brightness,
                baseColor.b * brightness,
                baseColor.a * brightness);

            _target.color = plateColor;
        }
    }
}