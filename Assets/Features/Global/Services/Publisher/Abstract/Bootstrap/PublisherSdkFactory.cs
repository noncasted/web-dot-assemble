using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using UnityEngine;

namespace Global.Publisher.Abstract.Bootstrap
{
    public abstract class PublisherSdkFactory : ScriptableObject, IGlobalServiceAsyncFactory
    {
        public abstract UniTask Create(IDependencyRegister builder, IGlobalSceneLoader sceneLoader, IGlobalUtils utils);
    }
}