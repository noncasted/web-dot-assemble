using System;

namespace Menu.Achievements.Definitions
{
    public interface IAchievementCompletionChecker
    {
        event Action Completed;
        
        void Enable();
        void Disable();
    }
}