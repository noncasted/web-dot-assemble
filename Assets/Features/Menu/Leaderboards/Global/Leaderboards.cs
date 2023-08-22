using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Global.Services.Publisher.Abstract.Leaderboards;

namespace Menu.Leaderboards.Global
{
    public class Leaderboards : ILeaderboards
    {
        public Leaderboards(ILeaderboardsProvider provider, ILeaderboardsConfig config)
        {
            _provider = provider;
            _config = config;
        }

        private readonly ILeaderboardsProvider _provider;
        private readonly ILeaderboardsConfig _config;

        public void Set(ILeaderboardLink link, int score)
        {
            _provider.SetScore(link, score);
        }

        public async UniTask<IReadOnlyList<LeaderboardUser>> Get(ILeaderboardLink link, CancellationToken cancellation)
        {
            var entries = await _provider.GetLeaderBoard(
                link,
                _config.QuantityTop,
                _config.QuantityAround,
                cancellation);

            return entries;
        }
    }
}