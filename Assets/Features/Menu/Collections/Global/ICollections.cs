using System.Collections.Generic;

namespace Menu.Collections.Global
{
    public interface ICollections
    {
        IReadOnlyList<AvatarHandle> All { get; }
    }
}