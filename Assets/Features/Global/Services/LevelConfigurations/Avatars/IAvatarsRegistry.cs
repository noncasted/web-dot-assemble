using System.Collections.Generic;

namespace Global.LevelConfigurations.Avatars
{
    public interface IAvatarsRegistry
    {
        IReadOnlyList<IAvatarDefinition> Avatars { get; }
    }
}