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
        public IReadOnlyList<IAvatarDefinition> Avatars => Objects;
    }
}