using UnityEngine;
#if USE_ADDRESSABLES
using UnityEngine.AddressableAssets;
#endif
namespace Global.System.Objects.Abstract
{
    public abstract class BaseObjectAsset<T> : ScriptableObject, IObjectAsset<T> where T : Object
    {
        public abstract T Object { get; }
#if USE_ADDRESSABLES
        public abstract AssetReferenceT<T> Reference { get; }
#endif
    }
}