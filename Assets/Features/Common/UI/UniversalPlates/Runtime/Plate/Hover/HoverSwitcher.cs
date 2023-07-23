using UnityEngine;

namespace Common.UI.UniversalPlates.Runtime.Plate.Hover
{
    public class HoverSwitcher : IPlateFeature
    {
        [SerializeField] private HoverTrigger _trigger;

        [SerializeField] private GameObject _on;
        [SerializeField] private GameObject _off;

        public bool IsUpdatable => true;

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
            if (_trigger.IsHovered == true)
            {
                _on.SetActive(true);
                _off.SetActive(false);
            }
            else
            {
                _on.SetActive(false);
                _off.SetActive(true);
            }
        }
    }
}