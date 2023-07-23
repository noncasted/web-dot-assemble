using UnityEngine;

namespace Common.UI.UniversalPlates.Runtime
{
    [DisallowMultipleComponent]
    public class UniversalPlate : MonoBehaviour
    {
        [SerializeReference]
        private IPlateFeature[] _features;

        private bool _isLocked;
        
        private void Awake()
        {
            foreach (var feature in _features)
                feature.Init();
            
            UpdateProperties();
        }

        private void OnDisable()
        {
            foreach (var feature in _features)
                feature.Disable();
        }

        public void UpdateProperties()
        {
            if (_isLocked == true || _features == null)
                return;
            
            foreach (var feature in _features)
                feature.Update();
        }

        public void Lock()
        {
            _isLocked = true;
            
            foreach (var feature in _features)
                feature.OnLocked();
        }

        public void Unlock()
        {
            _isLocked = false;
        }
        
        private void Update()
        {
            if (_isLocked == true)
                return;
            
            foreach (var feature in _features)
                feature.Update();
        }
    }
}