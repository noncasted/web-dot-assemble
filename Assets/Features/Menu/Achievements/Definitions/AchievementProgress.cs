﻿using System;

namespace Menu.Achievements.Definitions
{
    public class AchievementProgress : IAchievementProgress
    {
        public AchievementProgress(AchievementType type, int target, int progress)
        {
            _type = type;
            _target = target;
            _progress = progress;
        }

        private readonly AchievementType _type;
        private readonly int _target;

        private int _previousFetch;
        private int _progress;

        public int Target => _target;
        public int Progress => _progress;
        public int PreviousFetch => _progress;
        public bool IsCompleted => Progress == Target;
        
        public event Action<IAchievementProgress> Updated;
        
        public void Update(int progress)
        {
            var previous = _progress;
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