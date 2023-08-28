using System.Collections.Generic;

namespace Global.LevelConfiguration.Avatars
{
    public interface IAvatarsRegistry
    {
        IReadOnlyList<IAvatarDefinition> Avatars { get; }
    }
}