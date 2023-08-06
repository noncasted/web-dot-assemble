using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Shop.UI
{
    public class ShopController : IShopController, ITab
    {
        public ShopController(IShopView view)
        {
            _view = view;
        }

        private readonly IShopView _view;

        public RectTransform Transform => _view.Transform;
        
        public void Activate()
        {
            
        }

        public void Deactivate()
        {
            
        }
    }
}