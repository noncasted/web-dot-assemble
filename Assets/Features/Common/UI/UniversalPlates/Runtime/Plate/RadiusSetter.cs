using System;
using Common.UI.UniversalPlates.Setup;
using MPUIKIT;
using UnityEngine;

namespace Common.UI.UniversalPlates.Runtime.Plate
{
    [Serializable]
    public class RadiusSetter : IPlateFeature
    {
        [SerializeField] private UniversalPlateRadiusConfig _config;

        [SerializeField] private MPImage _plate;
        [SerializeField] private MPImage _outline;
        [SerializeField] private MPImage _center;

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
            if (_config == null
                || _plate == null
                || _outline == null
                || _center == null)
                return;

            // _plate.ou = _config.Out;
            // _outline.Radius = _config.Out;
            // _center.Radius = _config.In;
        }
    }
}