using System.Threading;
using Cysharp.Threading.Tasks;
using Menu.Achievements.Definitions;

namespace Menu.Achievements.UI
{
    public interface IAchievementEntryView
    {
        UniTask Show(IAchievement achievement, CancellationToken cancellation);
        UniTask Hide(CancellationToken cancellation);
        void Disable();
    }
}