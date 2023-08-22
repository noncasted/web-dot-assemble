using Menu.Achievements.Common;
using UnityEngine;

namespace Menu.Achievements.UI
{
    [CreateAssetMenu(fileName = AchievementsRoutes.EntryViewConfigName,
        menuName = AchievementsRoutes.EntryViewConfigPath)]
    public class AchievementEntryViewConfig : ScriptableObject
    {
        [SerializeField] [Min(0f)] private float _showTime;
        [SerializeField] [Min(0f)] private float _hideTime;

        public float ShowTime => _showTime;
        public float HideTime => _hideTime;
    }
}