using UnityEngine;

namespace Menu.Achievements.Definitions
{
    public interface IAchievementData
    {
        Sprite Icon { get; }
        string Text { get; }
    }
}