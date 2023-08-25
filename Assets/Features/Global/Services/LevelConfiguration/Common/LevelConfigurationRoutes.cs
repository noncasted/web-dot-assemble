using Global.Common;

namespace Global.Services.LevelConfiguration.Common
{
    public class LevelConfigurationRoutes
    {
        public const string ServiceName = GlobalAssetsPrefixes.Service + "LevelConfigurationProvider";
        public const string ServicePath = GlobalAssetsPaths.Root + "Configuration/Provider";
        
        public const string ConfigName = "LevelConfiguration";
        public const string ConfigPath = GlobalAssetsPaths.Root + "Configuration/Configuration";
        
        public const string AvatarName = "AvatarDefinition";
        public const string AvatarPath = GlobalAssetsPaths.Root + "Configuration/Avatar";
        
        public const string AvatarsRegistryName = "AvatarsRegistry";
        public const string AvatarsRegistryPath = GlobalAssetsPaths.Root + "Configuration/AvatarsRegistry";
    }
}