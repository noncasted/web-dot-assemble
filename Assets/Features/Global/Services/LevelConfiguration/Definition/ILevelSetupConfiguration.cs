using Global.LevelConfiguration.Avatars;

namespace Global.LevelConfiguration.Definition
{
    public interface ILevelSetupConfiguration
    {
        IAvatarDefinition PlayerAvatar { get; }
        IAvatarDefinition EnemyAvatar { get; }
        
        ILevelConfiguration LevelData { get; }
    }
}