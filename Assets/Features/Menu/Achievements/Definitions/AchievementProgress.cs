using System;

namespace Menu.Achievements.Definitions
{
    public class AchievementProgress : IAchievementProgress
    {
        public AchievementProgress(TargetAchievement type, int target, int progress)
        {
            _type = type;
            _target = target;
            _progress = progress;
        }

        private readonly TargetAchievement _type;
        private readonly int _target;

        private int _previousFetch;
        private int _progress;

        public int Target => _target;
        public int Value => _progress;
        public int PreviousFetch => _previousFetch;
        public bool IsCompleted => Value == Target;
        
        public event Action<IAchievementProgress> Updated;
        
        public void Update(int progress)
        {
            _progress = progress;
            
            if (_progress > _target)
                _progress = _target;
            
            Updated?.Invoke(this);
        }

        public void Fetch()
        {
            _previousFetch = _progress;
        }
    }
}