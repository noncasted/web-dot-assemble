using UnityEngine;

#if USE_ADDRESSABLES
using UnityEngine.AddressableAssets;
#endif

namespace Global.System.Objects.Abstract
{
    public interface IObjectAsset<T> where T : Object
    {
        T Object { get; }
#if USE_ADDRESSABLES
        AssetReferenceT<T> Reference { get; }
#endif
    }
}