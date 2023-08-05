using Features.Global.Services.LevelConfiguration.Avatars;

namespace Features.Global.Services.LevelConfiguration.Definition
{
    public interface ILevelSetupConfiguration
    {
        IAvatarDefinition PlayerAvatar { get; }
        IAvatarDefinition EnemyAvatar { get; }
        
        ILevelConfiguration LevelData { get; }
    }
}