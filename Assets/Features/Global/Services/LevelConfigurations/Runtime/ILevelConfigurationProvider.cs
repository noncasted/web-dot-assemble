using Cysharp.Threading.Tasks;
using GamePlay.Loop.Modes;
using Global.LevelConfigurations.Avatars;
using Global.LevelConfigurations.Definition;

namespace Global.LevelConfigurations.Runtime
{
    public interface ILevelConfigurationProvider
    {
        GameMode Mode { get; }
        IAvatarDefinition PlayerAvatar { get; }

        void SetMode(GameMode mode);
        void SetPlayerAvatar(IAvatarDefinition playerAvatar);
        UniTask<ILevelConfiguration> GetConfiguration();
        UniTask NextConfiguration();
    }
}