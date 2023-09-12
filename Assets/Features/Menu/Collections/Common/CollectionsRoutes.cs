using Menu.Common.Paths;

namespace Menu.Collections.Common
{
    public class CollectionsRoutes
    {
        public const string ServiceName = MenuAssetsPrefixes.Service + "Collections_Global";
        public const string ServicePath = MenuAssetsPaths.Root + "Collections/Global";

        public const string ControllerName = MenuAssetsPrefixes.Service + "Collections_Ui";
        public const string ControllerPath = MenuAssetsPaths.Root + "Collections/Ui";
        
        public const string EntryViewConfigName = "EntryViewConfig";
        public const string EntryViewConfigPath = MenuAssetsPaths.Root + "Collections/EntryViewConfig";
    }
}