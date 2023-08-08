using System.Collections.Generic;
using Menu.Achievements.Definitions;

namespace Menu.Achievements.Global
{
    public interface IAchievementsConfig
    {
        IReadOnlyList<AchievementConfig> GetConfigs();
    }
}