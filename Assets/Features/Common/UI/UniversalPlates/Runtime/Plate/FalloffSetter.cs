using System;
using Common.UI.UniversalPlates.Setup;
using MPUIKIT;
using UnityEngine;

namespace Common.UI.UniversalPlates.Runtime.Plate
{
    [Serializable]
    public class FalloffSetter : IPlateFeature
    {
        [SerializeField] private UniversalPlateFalloffConfig _config;

        [SerializeField] private MPImage[] _childObjects;

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
            if (_config == null)
                return;

            foreach (var image in _childObjects)
                image.FalloffDistance = _config.Value;
        }
    }
}