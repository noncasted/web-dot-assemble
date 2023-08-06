using UnityEngine;

namespace Menu.Shop.UI
{
    [DisallowMultipleComponent]
    public class ShopView : MonoBehaviour, IShopView
    {
        private RectTransform _transform;

        public RectTransform Transform => _transform;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
        }
    }
}