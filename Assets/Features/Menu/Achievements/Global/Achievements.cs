using System.Collections.Generic;
using Menu.Achievements.Definitions;

namespace Menu.Achievements.Global
{
    public class Achievements : IAchievementsProvider
    {
        public IReadOnlyList<IAchievementData> GetAll()
        {
            return null;
        }

        public IReadOnlyList<IAchievementData> GetProgressed()
        {
            return null;
        }
    }
}