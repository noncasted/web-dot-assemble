using GamePlay.Level.Common;

namespace GamePlay.Level.Dots.Common
{
    public class DotsRoutes
    {
        public const string DefinitionName = "DotDefinition";
        public const string DefinitionPath = LevelAssetsPaths.Root + "Dots/" + "DotDefinition";

        public const string FactoryName = LevelAssetsPrefixes.Service + "DotFactory";
        public const string FactoryPath = LevelAssetsPaths.Root + "Dots/" + "Factory";

        public const string StorageName = LevelAssetsPrefixes.Service + "DotDefinitionStorage";
        public const string StoragePath = LevelAssetsPaths.Root + "Dots/" + "Storage";
    }
}