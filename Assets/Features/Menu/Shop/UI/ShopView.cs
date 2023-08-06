using UnityEngine;

namespace Menu.Shop.UI
{
    [DisallowMultipleComponent]
    public class ShopView : MonoBehaviour, IShopView
    {
        public RectTransform Transform { get; private set; }

        private void Awake()
        {
            Transform = GetComponent<RectTransform>();
        }
    }
}