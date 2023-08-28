using Menu.Achievements.Common;
using UnityEngine;

namespace Menu.Achievements.Definitions
{
    [CreateAssetMenu(fileName = AchievementsRoutes.EntryName,
        menuName = AchievementsRoutes.EntryPath)]
    public class AchievementConfig : ScriptableObject
    {
        [SerializeField] private AchievementType _type;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;
        [SerializeField] [Min(0)] private int _targetProgress;

        public AchievementType Type => _type;
        public string Name => _name;
        public string Description => _description;
        public Sprite Icon => _icon;
        public int TargetProgress => _targetProgress;

        public void SetType(AchievementType type)
        {
            _type = type;
        }
    }
}