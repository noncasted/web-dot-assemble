using Global.LevelConfigurations.Avatars;

namespace Menu.Collections.Global
{
    public readonly struct AvatarHandle
    {
        public AvatarHandle(IAvatarDefinition definition, bool isUnlocked)
        {
            Definition = definition;
            IsUnlocked = isUnlocked;
        }
        
        public readonly IAvatarDefinition Definition;
        public readonly bool IsUnlocked;
    }
}