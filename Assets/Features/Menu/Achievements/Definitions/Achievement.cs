namespace Menu.Achievements.Definitions
{
    public class Achievement : IAchievement
    {
        public Achievement(
            IAchievementProgress progress,
            IAchievementData data, 
            IAchievementCompletionChecker completionChecker)
        {
            _progress = progress;
            _data = data;
            _completionChecker = completionChecker;
        }
        
        private readonly IAchievementProgress _progress;
        private readonly IAchievementData _data;
        private readonly IAchievementCompletionChecker _completionChecker;

        public IAchievementProgress Progress => _progress;
        public IAchievementData Data => _data;
        public IAchievementCompletionChecker CompletionChecker => _completionChecker;
    }
}