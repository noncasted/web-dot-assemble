using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Global.System.Objects.Abstract
{
    public abstract class BaseObjectAsset<T> : ScriptableObject, IObjectAsset<T> where T : Object
    {
        public abstract T Object { get; }
        public abstract AssetReferenceT<T> Reference { get; }
    }
}