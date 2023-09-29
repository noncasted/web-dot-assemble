using System.Collections.Generic;
using Menu.Achievements.Definitions;

namespace Menu.Achievements.Global
{
    public interface IAchievementFactory
    {
        IAchievement Create(AchievementConfig config, IReadOnlyDictionary<TargetAchievement, int> save);
    }
}