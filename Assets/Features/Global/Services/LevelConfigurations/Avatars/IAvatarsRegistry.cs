using System.Collections.Generic;

namespace Global.LevelConfigurations.Avatars
{
    public interface IAvatarsRegistry
    {
        IReadOnlyList<IAvatarDefinition> List { get; }
        IReadOnlyDictionary<string, IAvatarDefinition> Dictionary { get; }

        void Setup();
        IAvatarDefinition GetDefault();
    }
}