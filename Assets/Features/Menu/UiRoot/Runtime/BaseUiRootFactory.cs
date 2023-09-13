using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Cysharp.Threading.Tasks;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using UnityEngine;

namespace Menu.UiRoot.Runtime
{
    public abstract class BaseUiRootFactory : ScriptableObject, ILocalServiceAsyncFactory
    {
        public abstract UniTask Create(
            IDependencyRegister builder, 
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            IEventLoopsRegistry callbacks);
    }
}