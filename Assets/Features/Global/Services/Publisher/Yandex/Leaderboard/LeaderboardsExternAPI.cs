using System.Runtime.InteropServices;

namespace Global.Services.Publisher.Yandex.Leaderboard
{
    public class LeaderboardsExternAPI : ILeaderboardsAPI
    {
        [DllImport("__Internal")]
        private static extern void SetLeaderboard(string target, int score);

        [DllImport("__Internal")]
        private static extern void GetLeaderboard(string target, int quantityTop, int quantityAround);

        public void SetLeaderboard_Internal(string target, int score)
        {
            SetLeaderboard(target, score);
        }

        public void GetLeaderboard_Internal(string target, int quantityTop, int quantityAround)
        {
            GetLeaderboard(target, quantityTop, quantityAround);
        }
    }
}