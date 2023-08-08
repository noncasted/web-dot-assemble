using System;

namespace Menu.Achievements.Definitions
{
    public interface IAchievementProgress
    {
        int Target { get; }
        int Progress { get; }
        int PreviousFetch { get; }
        bool IsCompleted { get; }

        event Action<IAchievementProgress> Updated;

        void Update(int progress);
        void Fetch();
    }
}