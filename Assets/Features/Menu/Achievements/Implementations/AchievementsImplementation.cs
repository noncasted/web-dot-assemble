using System;
using Global.LevelConfigurations.Avatars;
using Menu.Common.Tasks.Abstract;
using Menu.Common.Tasks.Runtime;
using UnityEngine;

namespace Menu.Achievements.Implementations
{
    [Serializable]
    public class EnterGameAchievementTrigger : ProgressionTask
    {
        public EnterGameAchievementTrigger(int value) : base(value)
        {
        }
    }

    [Serializable]
    public class GrantAvatarTrigger
    {
        [SerializeField] private AvatarDefinition _definition;

        public IAvatarDefinition Definition => _definition;
    }

    public class EnterGameAchievementDefinition :
        TaskCompletionDefinition<EnterGameAchievementTrigger, GrantAvatarTrigger>
    {
    }
}