using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Scenes.ScenesFlow.Handling.Data
{
    [InlineEditor]
    public class SceneData : ScriptableObject, ISceneAsset
    {
        [SerializeField] private SceneField _name;
        [SerializeField] private SceneAssetReference _reference;

        public string Name => _name.SceneName;
        public SceneAssetReference Reference => _reference;
    }
}