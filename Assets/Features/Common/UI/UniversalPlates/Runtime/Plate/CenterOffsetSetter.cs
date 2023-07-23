﻿using System;
using Common.UI.UniversalPlates.Setup;
using UnityEngine;

namespace Common.UI.UniversalPlates.Runtime.Plate
{
    [Serializable]
    public class CenterOffsetSetter : IPlateFeature
    {
        [SerializeField] private UniversalPlateCenterOffsetConfig _config;
        [SerializeField] private RectTransform _center;
        
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
            if (_config == null || _center == null)
                return;

            _center.offsetMin = new Vector2(_config.Value, _config.Value);
            _center.offsetMax = new Vector2(-_config.Value, -_config.Value);
        }
    }
}