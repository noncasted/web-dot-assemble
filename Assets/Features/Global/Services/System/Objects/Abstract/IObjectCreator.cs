using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Global.System.Objects.Abstract
{
    public interface IObjectCreator
    {
        UniTask<T> Create<T>(IObjectAsset<T> asset) where T : Object;

        UniTask<T> Create<T>(
            IObjectAsset<T> asset,
            Vector2 position) where T : Object;

        UniTask<T> Create<T>(
            IObjectAsset<T> asset,
            Vector3 position) where T : Object;

        UniTask<T> Create<T>(
            IObjectAsset<T> asset,
            Vector2 position,
            Transform parent) where T : Object;

        UniTask<T> Create<T>(
            IObjectAsset<T> asset,
            Vector3 position,
            Transform parent) where T : Object;

        UniTask<T> Create<T>(
            IObjectAsset<T> asset,
            Vector2 position,
            float angle) where T : Object;

        UniTask<T> Create<T>(
            IObjectAsset<T> asset,
            Vector3 position,
            Quaternion rotation) where T : Object;

        UniTask<T> Create<T>(
            IObjectAsset<T> asset,
            Vector2 position,
            Scene scene) where T : Object;

        UniTask<T> Create<T>(
            IObjectAsset<T> asset,
            Vector3 position,
            Scene scene) where T : Object;

        UniTask<T> Create<T>(
            IObjectAsset<T> asset,
            Vector2 position,
            Scene scene,
            float angle) where T : Object;

        UniTask<T> Create<T>(
            IObjectAsset<T> asset,
            Vector3 position,
            Scene scene,
            Quaternion rotation)
            where T : Object;

        UniTask<T> Create<T>(
            IObjectAsset<T> asset,
            Vector2 position,
            Transform parent,
            Scene scene) where T : Object;

        UniTask<T> Create<T>(
            IObjectAsset<T> asset,
            Vector3 position,
            Transform parent,
            Scene scene) where T : Object;

        UniTask<T> Create<T>(
            IObjectAsset<T> asset,
            Vector2 position,
            Transform parent,
            Scene scene, float angle) where T : Object;

        UniTask<T> Create<T>(
            IObjectAsset<T> asset,
            Vector3 position,
            Transform parent,
            Scene scene,
            Quaternion rotation) where T : Object;
    }
}