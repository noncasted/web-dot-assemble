using System.Collections.Generic;
using Menu.Achievements.Definitions;

namespace Menu.Achievements.Global
{
    public interface IAchievementsProvider
    {
        IReadOnlyList<IAchievementData> GetAll();
        IReadOnlyList<IAchievementData> GetProgressed();
    }
}