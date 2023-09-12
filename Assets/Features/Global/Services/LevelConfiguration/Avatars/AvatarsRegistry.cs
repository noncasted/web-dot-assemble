using System.Collections.Generic;
using Common.Serialization.ScriptableRegistries;
using Global.LevelConfiguration.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.LevelConfiguration.Avatars
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelConfigurationRoutes.AvatarsRegistryName,
        menuName = LevelConfigurationRoutes.AvatarsRegistryPath)]
    public class AvatarsRegistry : ScriptableRegistry<AvatarDefinition>, IAvatarsRegistry
    {
        public IReadOnlyList<IAvatarDefinition> Avatars => Objects;
    }
}