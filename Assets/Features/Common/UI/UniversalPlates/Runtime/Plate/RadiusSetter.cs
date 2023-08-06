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
                || _outline == null)
                return;

            var plateRectangle = _plate.Rectangle;
            plateRectangle.CornerRadius = new Vector4(_config.Out, _config.Out, _config.Out, _config.Out);
            var outlineRectangle = _plate.Rectangle;
            outlineRectangle.CornerRadius = new Vector4(_config.In, _config.In, _config.In, _config.In);
        }
    }
}