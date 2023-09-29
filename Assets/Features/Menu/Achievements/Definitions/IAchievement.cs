namespace Menu.Achievements.Definitions
{
    public interface IAchievement
    {
        IAchievementProgress Progress { get; }
        IAchievementData Data { get; }
        IAchievementCompletionChecker CompletionChecker { get; }
        IAchievementCompletionProcessor CompletionProcessor { get; }
    }
}