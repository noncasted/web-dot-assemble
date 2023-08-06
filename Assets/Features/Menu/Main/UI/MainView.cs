using Features.Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Main.UI
{
    [DisallowMultipleComponent]
    public class MainView : MonoBehaviour, IMainView
    {
        [SerializeField] private TabNavigation _navigation;

        public ITabNavigation Navigation => _navigation;
        public RectTransform Transform { get; private set; }

        private void Awake()
        {
            Transform = GetComponent<RectTransform>();
        }
    }
}