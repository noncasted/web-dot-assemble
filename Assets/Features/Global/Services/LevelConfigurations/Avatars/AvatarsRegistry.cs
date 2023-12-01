using System.Collections.Generic;
using Common.Serialization.ScriptableRegistries;
using Global.LevelConfigurations.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.LevelConfigurations.Avatars
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelConfigurationRoutes.AvatarsRegistryName,
        menuName = LevelConfigurationRoutes.AvatarsRegistryPath)]
    public class AvatarsRegistry : ScriptableRegistry<AvatarDefinition>, IAvatarsRegistry
    {
        [SerializeField] private AvatarDefinition _default;
        
        public IReadOnlyList<IAvatarDefinition> List => Objects;
        
        private IReadOnlyDictionary<string, IAvatarDefinition> _dictionary;
        public IReadOnlyDictionary<string, IAvatarDefinition> Dictionary => _dictionary;

        public void Setup()
        {
            var dictionary = new Dictionary<string, IAvatarDefinition>();

            foreach (var avatar in Objects)
                dictionary.Add(avatar.Product.Id, avatar);

            _dictionary = dictionary;
        }

        public IAvatarDefinition GetDefault()
        {
            return _default;
        }
    }
}