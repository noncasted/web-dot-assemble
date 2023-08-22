using System.Collections.Generic;
using Common.Serialization.ScriptableRegistries;
using Menu.Achievements.Common;
using Menu.Achievements.Global;
using UnityEngine;

namespace Menu.Achievements.Definitions
{
    [CreateAssetMenu(fileName = AchievementsRoutes.RegistryName, menuName = AchievementsRoutes.RegistryPath)]
    public class AchievementsRegistry : ScriptableRegistry<AchievementConfig>, IAchievementsConfigsRegistry
    {
        public IReadOnlyList<AchievementConfig> GetConfigs()
        {
            return Objects;
        }
    }
}