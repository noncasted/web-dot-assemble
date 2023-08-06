using UnityEngine;

namespace Menu.Settings.UI
{
    [DisallowMultipleComponent]
    public class SettingsView : MonoBehaviour, ISettingsView
    {
        private RectTransform _transform;

        public RectTransform Transform => _transform;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
        }
    }
}