using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Purchases;
using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Shop.UI
{
    [DisallowMultipleComponent]
    public class ShopView : MonoBehaviour, IShopView
    {
        [SerializeField] private ShopEntry[] _shopEntries;
        
        private ITabNavigation _navigation;
        private RectTransform _transform;
    
        public ITabNavigation Navigation => _navigation;
        public RectTransform Transform => _transform;

        private void Awake()
        {
            _navigation = GetComponent<ITabNavigation>();
            _transform = GetComponent<RectTransform>();
        }
        
        public async UniTask Show(IReadOnlyList<IProductLink> products, CancellationToken cancellation)
        {
            var showAmount = _shopEntries.Length;
            var entries = _shopEntries.ToList();
            var showTasks = new List<UniTask>();
            
            for (var i = 0; i < showAmount; i++)
            {
                var product = products[i];
                var slotFound = false;

                foreach (var entry in _shopEntries)
                {
                    if (entry.PrimaryProducts.Contains(product) == false)
                        continue;

                    slotFound = true;
                    showTasks.Add(entry.Show(product));
                    entries.Remove(entry);
                }
                
                if (slotFound == true)
                    continue;

                var firstEntry = entries.First();
                showTasks.Add(firstEntry.Show(product));
                entries.Remove(firstEntry);
            }

            await UniTask.WhenAll(showTasks);
        }
    }
}