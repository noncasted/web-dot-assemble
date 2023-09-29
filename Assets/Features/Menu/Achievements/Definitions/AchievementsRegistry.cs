using System.Collections.Generic;
using Common.Serialization.ScriptableRegistries;
using Menu.Achievements.Common;
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

        protected override void OnRegistryValidation(IReadOnlyList<AchievementConfig> objects)
        {
            for (var i = 0; i < objects.Count; i++)
                objects[i].SetType((TargetAchievement)i);
        }
    }
}