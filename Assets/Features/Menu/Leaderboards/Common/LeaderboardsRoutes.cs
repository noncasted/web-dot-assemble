using Menu.Common.Paths;

namespace Menu.Leaderboards.Common
{
    public class LeaderboardsRoutes
    {
        public const string ServiceName = MenuAssetsPrefixes.Service + "Leaderboards_Global";
        public const string ServicePath = MenuAssetsPaths.Root + "Leaderboards/Global";

        public const string ControllerName = MenuAssetsPrefixes.Service + "Leaderboards_Ui";
        public const string ControllerPath = MenuAssetsPaths.Root + "Leaderboards/Ui";

        public const string ConfigName = MenuAssetsPrefixes.Config + "Leaderboards";
        public const string ConfigPath = MenuAssetsPaths.Root + "Leaderboards/Config";

        public const string EntriesName = MenuAssetsPrefixes.Config + "Leaderboards_Entries";
        public const string EntriesPath = MenuAssetsPaths.Root + "Leaderboards/Entries";
    }
}