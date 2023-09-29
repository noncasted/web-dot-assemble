using UnityEngine;

namespace Menu.Achievements.Definitions
{
    public interface IAchievementData
    {
        Sprite Icon { get; }
        string Name { get; }
        string Description { get; }
        TargetAchievement Type { get; }
    }
}