using System.Collections.Generic;

namespace Menu.Achievements.Definitions
{
    public interface IAchievementsConfigsRegistry
    {
        IReadOnlyList<AchievementConfig> GetConfigs();
    }
}