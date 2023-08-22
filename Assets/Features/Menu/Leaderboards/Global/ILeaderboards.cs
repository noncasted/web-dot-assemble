using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Global.Services.Publisher.Abstract.Leaderboards;

namespace Menu.Leaderboards.Global
{
    public interface ILeaderboards
    {
        void Set(ILeaderboardLink link, int score);
        UniTask<IReadOnlyList<LeaderboardUser>> Get(ILeaderboardLink link, CancellationToken cancellation);
    }
}