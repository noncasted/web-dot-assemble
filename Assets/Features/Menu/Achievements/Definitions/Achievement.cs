namespace Menu.Achievements.Definitions
{
    public class Achievement : IAchievement
    {
        public Achievement(
            IAchievementProgress progress,
            IAchievementData data, 
            IAchievementCompletionChecker completionChecker,
            IAchievementCompletionProcessor completionProcessor)
        {
            _progress = progress;
            _data = data;
            _completionChecker = completionChecker;
            _completionProcessor = completionProcessor;
        }
        
        private readonly IAchievementProgress _progress;
        private readonly IAchievementData _data;
        private readonly IAchievementCompletionChecker _completionChecker;
        private readonly IAchievementCompletionProcessor _completionProcessor;

        public IAchievementProgress Progress => _progress;
        public IAchievementData Data => _data;
        public IAchievementCompletionChecker CompletionChecker => _completionChecker;
        public IAchievementCompletionProcessor CompletionProcessor => _completionProcessor;
    }
}