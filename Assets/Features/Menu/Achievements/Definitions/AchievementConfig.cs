using Menu.Achievements.Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Menu.Achievements.Definitions
{
    [CreateAssetMenu(fileName = AchievementsRoutes.EntryName,
        menuName = AchievementsRoutes.EntryPath)]
    public class AchievementConfig : ScriptableObject
    {
        [SerializeField] private AchievementType _type;
        [SerializeField] private string _text;
        [SerializeField] private Sprite _icon;
        [SerializeField] [Min(0)] private int _targetProgress;

        public AchievementType Type => _type;
        public string Text => _text;
        public Sprite Icon => _icon;
        public int TargetProgress => _targetProgress;
    }
}