using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Services.Setup.Service;
using Global.Services.Setup.Service.Scenes;
using UnityEngine;

namespace Global.Services.Publisher.Abstract.Bootstrap
{
    public abstract class PublisherSdkAsset : ScriptableObject, IGlobalServiceAsyncFactory
    {
        public abstract UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks);
    }
}