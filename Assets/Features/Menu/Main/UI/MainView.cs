using UnityEngine;

namespace Menu.Main.UI
{
    [DisallowMultipleComponent]
    public class MainView : MonoBehaviour, IMainView
    {
        private RectTransform _transform;

        public RectTransform Transform => _transform;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
        }
    }
}