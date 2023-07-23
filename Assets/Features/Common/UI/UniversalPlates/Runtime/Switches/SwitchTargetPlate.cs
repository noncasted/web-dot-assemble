using System;
using Common.UI.UniversalPlates.Setup;
using MPUIKIT;
using UnityEngine;

namespace Common.UI.UniversalPlates.Runtime.Switches
{
    [Serializable]
    public struct SwitchTargetPlate : IColorSwitchTarget
    {
        [SerializeField] private UniversalColor _activeColor;
        [SerializeField] private UniversalColor _baseColor;
        
        [SerializeField] private MPImage _image;

        public void Init()
        {
        }

        public void ToActive(float progress)
        {
            var color = Color.Lerp(_baseColor.Value, _activeColor.Value, progress);

            _image.color = color;
        }

        public void ToBase(float progress)
        {
            var color = Color.Lerp(_activeColor.Value, _baseColor.Value, progress);

            _image.color = color;
        }
    }
}