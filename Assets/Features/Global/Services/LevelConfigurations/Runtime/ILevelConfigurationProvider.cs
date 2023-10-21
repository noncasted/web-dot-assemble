using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Dots.Definitions;
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
        IReadOnlyList<IDotDefinition> GetSelectedDots();
        void UpdateSelectedDots(IReadOnlyList<IDotDefinition> dots);
        UniTask<ILevelConfiguration> GetConfiguration();
        UniTask NextConfiguration();
    }
}