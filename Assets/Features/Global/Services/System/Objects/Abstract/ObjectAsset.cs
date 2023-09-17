using System;
using UnityEngine;
#if USE_ADDRESSABLES
using UnityEngine.AddressableAssets;
#endif
using Object = UnityEngine.Object;

namespace Global.System.Objects.Abstract
{
    [Serializable]
    public class ObjectAsset<T> : IObjectAsset<T> where T : Object
    {
        [SerializeField] private T _object;
#if USE_ADDRESSABLES
        [SerializeField] private AssetReferenceT<T> _reference;
#endif

        public T Object => _object;
#if USE_ADDRESSABLES
        public AssetReferenceT<T> Reference => _reference;
#endif
    }
}