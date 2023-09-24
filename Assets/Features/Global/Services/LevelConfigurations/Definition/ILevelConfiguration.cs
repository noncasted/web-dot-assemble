using Global.LevelConfigurations.Avatars;

namespace Global.LevelConfigurations.Definition
{
    public interface ILevelConfiguration
    {
        public IAvatarDefinition Enemy { get; }
        int TargetScore { get; }
    }
}