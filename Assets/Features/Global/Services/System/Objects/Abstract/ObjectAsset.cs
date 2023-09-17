using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace Global.System.Objects.Abstract
{
    [Serializable]
    public class ObjectAsset<T> : IObjectAsset<T> where T : Object
    {
        [SerializeField] private T _object;
        [SerializeField] private AssetReferenceT<T> _reference;

        public T Object => _object;
        public AssetReferenceT<T> Reference => _reference;
    }
}