using UnityEngine;

namespace Menu.Achievements.Definitions
{
    public class AchievementData : IAchievementData
    {
        public AchievementData(Sprite sprite, string text, AchievementType type)
        {
            _sprite = sprite;
            _text = text;
            _type = type;
        }
        
        private readonly Sprite _sprite;
        private readonly string _text;
        private readonly AchievementType _type;

        public Sprite Icon => _sprite;
        public string Text => _text;
        public AchievementType Type => _type;
    }
}