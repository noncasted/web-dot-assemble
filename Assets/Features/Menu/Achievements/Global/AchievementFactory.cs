using System;
using System.Collections.Generic;
using Menu.Achievements.Definitions;

namespace Menu.Achievements.Global
{
    public class AchievementFactory : IAchievementFactory
    {
        public IAchievement Create(AchievementConfig config, IReadOnlyDictionary<AchievementType, int> save)
        {
            var currentProgress = 0;

            if (save.ContainsKey(config.Type) == true)
                currentProgress = save[config.Type];

            var progress = new AchievementProgress(config.Type, config.TargetProgress, currentProgress);
            var completionChecker = CreateCompletionChecker(config.Type, progress);
            var data = new AchievementData(config.Icon, config.Text, config.Type);

            return new Achievement(progress, data, completionChecker);
        }

        private IAchievementCompletionChecker CreateCompletionChecker(AchievementType type, IAchievementProgress progress)
        {
            switch (type)
            {
                case AchievementType.Tier_1:
                    return new Achievement_Tier_1(progress);
                case AchievementType.Tier_2:
                    break;
                case AchievementType.Tier_3:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            throw new NullReferenceException();
        }
    }
}