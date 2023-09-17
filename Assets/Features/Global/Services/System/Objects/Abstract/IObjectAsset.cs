using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Global.System.Objects.Abstract
{
    public interface IObjectAsset<T> where T : Object
    {
        T Object { get; }
        AssetReferenceT<T> Reference { get; }
    }
}