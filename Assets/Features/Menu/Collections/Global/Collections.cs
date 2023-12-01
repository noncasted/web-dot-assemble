using System.Collections.Generic;
using System.Linq;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Global.LevelConfigurations.Avatars;
using Global.Publisher.Abstract.DataStorages;
using Global.Publisher.Abstract.Purchases;
using Global.System.MessageBrokers.Runtime;

namespace Menu.Collections.Global
{       
    public class Collections : ICollections, IScopeEnableAsyncListener
    {
        public Collections(IAvatarsRegistry registry, IDataStorage storage)
        {
            _storage = storage;

            _products = new Dictionary<string, IProductLink>();
            _all = new Dictionary<IAvatarDefinition, AvatarHandle>();
            _allFromProducts = new Dictionary<IProductLink, IAvatarDefinition>();
            
            foreach (var avatar in registry.List)
                _all[avatar] = new AvatarHandle(avatar, false);

            foreach (var avatar in registry.List)
                _allFromProducts[avatar.Product] = avatar;

            foreach (var avatar in registry.List)
            {
                _products.Add(avatar.Product.Id, avatar.Product);
            }
        }
        
        private readonly IDataStorage _storage;

        private readonly Dictionary<string, IProductLink> _products;
        private readonly Dictionary<IAvatarDefinition, AvatarHandle> _all;
        private readonly Dictionary<IProductLink, IAvatarDefinition> _allFromProducts;
    
        private CollectionsSave _save;
        
        public IReadOnlyList<AvatarHandle> All => _all.Values.ToArray();
        
        public async UniTask OnEnabledAsync()
        {
            _save = await _storage.GetEntry<CollectionsSave>(CollectionsSave.Key);

            foreach (var (id, isUnlocked) in _save.Avatars)
            {
                var product = _products[id];
                var avatar = _allFromProducts[product];
                var handle = new AvatarHandle(avatar, isUnlocked);
                _all[avatar] = handle;
            }

            Msg.Listen<PurchaseEvent>(OnUnlocked);
        }
        
        private void OnUnlocked(PurchaseEvent purchase)
        {
            if (_allFromProducts.TryGetValue(purchase.ProductLink, out var avatar) == false)
                return;
            
            _all[avatar] = new AvatarHandle(avatar, true);
            _save.OnUnlocked(avatar.Product.Id);
        }
    }
}