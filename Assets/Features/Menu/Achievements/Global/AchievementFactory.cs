using System;
using System.Collections.Generic;
using Menu.Achievements.Definitions;

namespace Menu.Achievements.Global
{       
    public class AchievementFactory : IAchievementFactory
    {   
        public IAchievement Create(AchievementConfig config, IReadOnlyDictionary<TargetAchievement, int> save)
        {
            var currentProgress = 0;
            
            if (save.ContainsKey(config.Type) == true)
                currentProgress = save[config.Type];
            
            var progress = new AchievementProgress(config.Type, config.TargetProgress, currentProgress);
            var completionChecker = CreateCompletionChecker(config.Type, progress);
            var data = new AchievementData(config.Icon, config.Name, config.Description, config.Type);
            
            return new Achievement(progress, data, completionChecker, config.CompletionProcessor);
        }
            
        private IAchievementCompletionChecker CreateCompletionChecker(TargetAchievement type, IAchievementProgress progress)
        {
            return type switch
            {
                TargetAchievement.Ball_0 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Ball_1 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Ball_2 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Ball_3 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Ball_4 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Ball_5 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Ball_6 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Ball_7 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Ball_8 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Ball_9 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Ball_10 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Ball_11 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Ball_12 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Ball_13 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Ball_14 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Ball_15 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Mode_0 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Mode_1 => new ProgressCompletionChecker<TestPayload>(progress),
                TargetAchievement.Mode_3 => new ProgressCompletionChecker<TestPayload>(progress),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}