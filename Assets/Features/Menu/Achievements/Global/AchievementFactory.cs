using Menu.Achievements.Common;
using Menu.Common.Tasks.Abstract;
using Menu.Common.Tasks.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Achievements.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AchievementsRoutes.EntryName,
        menuName = AchievementsRoutes.EntryPath)]
    public class AchievementFactory : ScriptableObject, ITaskFactory
    {
        [SerializeField] private string _key;
        [SerializeField] private TaskData _data;
        [SerializeField] private int _target;
        
        [SerializeReference] private ITaskCompletionDefinition _definition;
        
        public string Key => _key;

        public IGoalTask Create(int currentProgress)
        {
            var progress = new TaskProgress(_target, currentProgress);
            _definition.CompletionProcessor.Construct(_definition.CompletionChecker);
            _definition.CompletionProcessor.Enable();
            return new GoalTask(_data, _definition.CompletionChecker, _definition.CompletionProcessor, progress);
        }
    }
}