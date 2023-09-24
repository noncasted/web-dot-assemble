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
            var data = new AchievementData(config.Icon, config.Name, config.Description, config.Type);

            return new Achievement(progress, data, completionChecker);
        }

        private IAchievementCompletionChecker CreateCompletionChecker(AchievementType type, IAchievementProgress progress)
        {
            return type switch
            {
                AchievementType.Ball_0 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Ball_1 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Ball_2 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Ball_3 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Ball_4 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Ball_5 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Ball_6 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Ball_7 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Ball_8 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Ball_9 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Ball_10 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Ball_11 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Ball_12 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Ball_13 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Ball_14 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Ball_15 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Mode_0 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Mode_1 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                AchievementType.Mode_3 => new AchievementTypeHandlerProgress<TestPayload>(progress),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}