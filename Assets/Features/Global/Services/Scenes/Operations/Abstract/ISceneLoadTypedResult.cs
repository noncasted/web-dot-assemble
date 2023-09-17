namespace Global.Scenes.Operations.Abstract
{
    public interface ISceneLoadTypedResult<T> : ISceneLoadResult
    {
        T Searched { get; }
    }
}