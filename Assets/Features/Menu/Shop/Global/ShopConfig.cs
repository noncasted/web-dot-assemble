using Global.Publisher.Abstract.Purchases;
using Menu.Shop.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Shop.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ShopRoutes.ShopConfigName, menuName = ShopRoutes.ShopConfigPath)]
    public class ShopConfig : ScriptableObject, IShopConfig
    {
        [SerializeField] private ProductLink _disableAds;

        public IProductLink DisableAds => _disableAds;
    }
}