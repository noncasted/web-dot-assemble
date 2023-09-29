using Menu.Achievements.Common;
using UnityEngine;

namespace Menu.Achievements.Definitions
{
    [CreateAssetMenu(fileName = AchievementsRoutes.EntryName,
        menuName = AchievementsRoutes.EntryPath)]
    public class AchievementConfig : ScriptableObject
    {
        [SerializeField] private TargetAchievement _type;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;
        [SerializeField] [Min(0)] private int _targetProgress;
        [SerializeReference] private IAchievementCompletionProcessor _completionProcessor;
        
        public TargetAchievement Type => _type;
        public string Name => _name;
        public string Description => _description;
        public Sprite Icon => _icon;
        public int TargetProgress => _targetProgress;
        public IAchievementCompletionProcessor CompletionProcessor => _completionProcessor;

        public void SetType(TargetAchievement type)
        {
            _type = type;
        }
    }
}