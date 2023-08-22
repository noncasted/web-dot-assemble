using System.Threading;
using Cysharp.Threading.Tasks;
using Menu.Achievements.Definitions;

namespace Menu.Achievements.UI
{
    public interface IAchievementEntryView
    {
        void Construct(IAchievement achievement);
        
        UniTask Show(CancellationToken cancellation);
        UniTask Hide(CancellationToken cancellation);
    }
}