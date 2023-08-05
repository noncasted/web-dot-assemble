namespace Menu.Achievements.Definitions
{
    public interface IAchievementProgress
    {
        int Target { get; }
        int Progress { get; }
        bool IsCompleted { get; }
    }
}