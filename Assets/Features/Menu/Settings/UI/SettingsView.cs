using UnityEngine;

namespace Menu.Settings.UI
{
    [DisallowMultipleComponent]
    public class SettingsView : MonoBehaviour, ISettingsView
    {
        public RectTransform Transform { get; private set; }

        private void Awake()
        {
            Transform = GetComponent<RectTransform>();
        }
    }
}