namespace Global.Scenes.ScenesFlow.Handling.Data
{
    public interface ISceneAsset
    {
        public string Name { get; }
        public SceneAssetReference Reference { get; }
    }
}