using UnityEngine;

namespace Menu.Achievements.Definitions
{
    public class AchievementData : IAchievementData
    {
        public AchievementData(Sprite sprite, string name, string description, AchievementType type)
        {
            _sprite = sprite;
            _name = name;
            _description = description;
            _type = type;
        }
        
        private readonly Sprite _sprite;
        private readonly string _name;
        private readonly string _description;
        private readonly AchievementType _type;

        public Sprite Icon => _sprite;
        public string Name => _name;
        public string Description => _description;
        public AchievementType Type => _type;
    }
}