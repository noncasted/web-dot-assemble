using System.Collections.Generic;
using Menu.Achievements.Definitions;

namespace Menu.Achievements.Global
{
    public interface IAchievements
    {
        IReadOnlyList<IAchievement> GetAll();
        IReadOnlyList<IAchievement> GetProgressed();
        void FetchAll();
        IAchievement Get(TargetAchievement type);
    }
}