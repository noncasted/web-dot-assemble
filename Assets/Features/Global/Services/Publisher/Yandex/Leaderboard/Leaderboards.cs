using Global.Services.Publisher.Abstract.Leaderboards;

namespace Global.Services.Publisher.Yandex.Leaderboard
{
    public class Leaderboards : ILeaderboards
    {
        public Leaderboards(ILeaderboardsAPI api)
        {
            _api = api;
        }

        private readonly ILeaderboardsAPI _api;

        public void SetScore(ILeaderboardEntry entry, int score)
        {
            var target = entry.GetLeaderboardName();

            _api.SetLeaderBoard_Internal(target, score);
        }
    }
}