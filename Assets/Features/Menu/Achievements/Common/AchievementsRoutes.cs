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
        
        public const string RegistryName = "AchievementsRegistry";
        public const string RegistryPath = MenuAssetsPaths.Root + "Achievements/Registry";
        
        public const string EntryViewConfigName = "EntryViewConfig";
        public const string EntryViewConfigPath = MenuAssetsPaths.Root + "Achievements/EntryViewConfig";
        
        public const string DebugName = "AchievementsDebug";
        public const string DebugPath = MenuAssetsPaths.Root + "Achievements/Debug";
    }
}