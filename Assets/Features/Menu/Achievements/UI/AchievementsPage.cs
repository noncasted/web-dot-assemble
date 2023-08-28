using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Menu.Achievements.Definitions;

namespace Menu.Achievements.UI
{
    public class AchievementsPage
    {
        public AchievementsPage(
            IReadOnlyList<IAchievement> achievements,
            IReadOnlyList<AchievementEntryView> views,
            AchievementPagePointView pagePoint)
        {
            _achievements = achievements;
            _views = views;
            _pagePoint = pagePoint;
        }

        private readonly IReadOnlyList<IAchievement> _achievements;
        private readonly IReadOnlyList<AchievementEntryView> _views;
        private readonly AchievementPagePointView _pagePoint;

        public void ActivatePage()
        {
            _pagePoint.Activate();
        }

        public void DeactivatePage()
        {
            _pagePoint.Deactivate();
        }

        public async UniTask Show(CancellationToken cancellation)
        {
            var tasks = new UniTask[_achievements.Count];

            for (var i = 0; i < _views.Count; i++)
            {
                if (i < _achievements.Count)
                {
                    tasks[i] = _views[i].Show(_achievements[i], cancellation);

                    await UniTask.Delay(0.008f);
                }
                else
                {
                    _views[i].Disable();
                }
            }

            await UniTask.WhenAll(tasks);
        }

        public async UniTask Hide(CancellationToken cancellation)
        {
            var tasks = new UniTask[_views.Count];

            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = _views[i].Hide(cancellation);
                
                await UniTask.Delay(0.02f);
            }

            await UniTask.WhenAll(tasks);
        }
    }
}