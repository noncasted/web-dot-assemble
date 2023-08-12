using System.Collections.Generic;
using Common.Serialization.ScriptableRegistries;
using Sirenix.OdinInspector;

namespace Global.Services.LevelConfiguration.Avatars
{
    [InlineEditor]
    public class AvatarsRegistry : ScriptableRegistry<AvatarDefinition>, IAvatarsRegistry
    {
        public IReadOnlyList<IAvatarDefinition> Avatars => Objects;
    }
}