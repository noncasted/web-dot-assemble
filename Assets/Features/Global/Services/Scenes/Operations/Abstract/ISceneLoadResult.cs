using UnityEngine.SceneManagement;

namespace Global.Scenes.Operations.Abstract
{
    public interface ISceneLoadResult
    {
        Scene Scene { get; }
    }
}