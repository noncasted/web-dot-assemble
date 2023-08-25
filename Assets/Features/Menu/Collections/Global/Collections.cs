using System.Collections.Generic;
using System.Linq;
using Global.Services.LevelConfiguration.Avatars;
using Global.Services.Publisher.Abstract.DataStorages;
using Global.Services.Setup.Service.Callbacks;

namespace Menu.Collections.Global
{       
    public class Collections : ICollections, IGlobalBootstrapListener
    {
        public Collections(IAvatarsRegistry registry, IDataStorage storage)
        {
            _storage = storage;

            _all = new Dictionary<IAvatarDefinition, AvatarHandle>();
            
            foreach (var avatar in registry.Avatars)
                _all[avatar] = new AvatarHandle(avatar, false);

            _allFromId = new Dictionary<int, IAvatarDefinition>();

            foreach (var avatar in registry.Avatars)
                _allFromId[avatar.Id] = avatar;
        }
        
        private readonly IDataStorage _storage;

        private readonly Dictionary<IAvatarDefinition, AvatarHandle> _all;
        private readonly Dictionary<int, IAvatarDefinition> _allFromId;
    
        private CollectionsSave _save;
        
        public IReadOnlyList<AvatarHandle> All => _all.Values.ToArray();
        
        public void OnBootstrapped()
        {
            _save = _storage.GetEntry<CollectionsSave>(CollectionsSave.Key);

            foreach (var (id, isUnlocked) in _save.Avatars)
            {
                var avatar = _allFromId[id];
                var handle = new AvatarHandle(avatar, isUnlocked);
                _all[avatar] = handle;
            }
        }
        
        public void Unlock(IAvatarDefinition definition)
        {
            _all[definition] = new AvatarHandle(definition, true);
            _save.OnUnlocked(definition.Id);
        }
    }
}