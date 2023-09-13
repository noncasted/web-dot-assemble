using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Global.Scenes.ScenesFlow.Handling.Data
{
    [System.Serializable]
    public class SceneAssetReference : AssetReference
    {
        public SceneAssetReference(string guid) : base(guid)
        {
        }

        public override bool ValidateAsset(Object obj)
        {
#if UNITY_EDITOR
            var type = obj.GetType();
            Debug.Log(obj.name);
            return typeof(UnityEditor.SceneAsset).IsAssignableFrom(type);
#else
            return false;
#endif
        }

        public override bool ValidateAsset(string path)
        {
#if UNITY_EDITOR
            var type = UnityEditor.AssetDatabase.GetMainAssetTypeAtPath(path);
            Debug.Log(path);

            return typeof(UnityEditor.SceneAsset).IsAssignableFrom(type);
#else
            return false;
#endif
        }

#if UNITY_EDITOR
        public new UnityEditor.SceneAsset _editorAsset => (UnityEditor.SceneAsset)base.editorAsset;
#endif
    }
}