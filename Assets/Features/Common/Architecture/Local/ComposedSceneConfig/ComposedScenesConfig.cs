using Common.Serialization.NestedScriptableObjects.Attributes;
using Global.Scenes.Operations.Data;
using UnityEngine;

namespace Common.Architecture.Local.ComposedSceneConfig
{
    [CreateAssetMenu(fileName = "ComposedSceneConfig",
        menuName = "Local/Config/ComposedScene")]
    public class ComposedScenesConfig : ScriptableObject
    {
        [SerializeField] [NestedScriptableObjectField] private SceneData _servicesScene;

        public ISceneAsset ServicesScene => _servicesScene;
    }
}