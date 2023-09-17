using UnityEngine.ResourceManagement.ResourceProviders;

namespace Global.Scenes.Operations.Abstract
{
    public interface ISceneInstanceProvider
    {
        SceneInstance SceneInstance { get; }
    }
}