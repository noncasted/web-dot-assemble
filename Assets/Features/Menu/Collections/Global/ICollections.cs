using System.Collections.Generic;
using Global.LevelConfiguration.Avatars;

namespace Menu.Collections.Global
{
    public interface ICollections
    {
        IReadOnlyList<AvatarHandle> All { get; }

        void Unlock(IAvatarDefinition definition);
    }
}