using Menu.Common;
using Menu.Common.Paths;

namespace Menu.Achievements.Common
{
    public class AchievementsRoutes
    {
        public const string ServiceName = MenuAssetsPrefixes.Service + "Achievements_Global";
        public const string ServicePath = MenuAssetsPaths.Root + "Achievements/Global";
        
        public const string ControllerName = MenuAssetsPrefixes.Service + "Achievements_Ui";
        public const string ControllerPath = MenuAssetsPaths.Root + "Achievements/Ui";
        
        public const string EntryName = "Achievement_";
        public const string EntryPath = MenuAssetsPaths.Root + "Achievements/Entry";
    }
}