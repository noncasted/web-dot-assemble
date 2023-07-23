using System;
using Common.UI.UniversalPlates.Setup;
using TMPro;
using UnityEngine;

namespace Common.UI.UniversalPlates.Runtime.Switches
{
    [Serializable]
    public class SwitchTargetText : IColorSwitchTarget
    {
        [SerializeField] private UniversalColor _activeColor;
        [SerializeField] private UniversalColor _baseColor;
        
        [SerializeField] private TMP_Text _text;

        public void Init()
        {
        }

        public void ToActive(float progress)
        {
            var color = Color.Lerp(_baseColor.Value, _activeColor.Value, progress);

            _text.color = color;
        }

        public void ToBase(float progress)
        {
            var color = Color.Lerp(_activeColor.Value, _baseColor.Value, progress);

            _text.color = color;
        }
    }
}