using System.Collections.Generic;

namespace Global.Services.LevelConfiguration.Avatars
{
    public interface IAvatarsRegistry
    {
        IReadOnlyList<IAvatarDefinition> Avatars { get; }
    }
}