using Menu.Achievements.Common;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Menu.Achievements.Global
{
    [CreateAssetMenu(fileName = AchievementsRoutes.DebugName,
        menuName = AchievementsRoutes.DebugPath)]
    public class AchievementsDebug : ScriptableObject
    {
        [SerializeField] private int _targetProgress;
        
        private IAchievements _achievements;

        [Inject]
        private void Construct(IAchievements achievements)
        {
            _achievements = achievements;
        }

        [Button]
        private void SetProgress()
        {
        }
    }
}