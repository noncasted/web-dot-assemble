using Features.Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Collections.UI
{
    [DisallowMultipleComponent]
    public class CollectionsView : MonoBehaviour, ICollectionsView
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