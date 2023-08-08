using Menu.Common;
using Menu.Common.Paths;

namespace Menu.Leaderboards.Common
{
    public class LeaderboardsRoutes
    {
        public const string ServiceName = MenuAssetsPrefixes.Service + "Leaderboards_Global";
        public const string ServicePath = MenuAssetsPaths.Root + "Leaderboards/Global";

        public const string ControllerName = MenuAssetsPrefixes.Service + "Leaderboards_Ui";
        public const string ControllerPath = MenuAssetsPaths.Root + "Leaderboards/Ui";
    }
}