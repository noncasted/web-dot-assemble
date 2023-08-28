using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Scenes.ScenesFlow.Runtime.Abstract;

namespace Common.Architecture.Local.Services.Abstract
{
    public interface ILocalServiceAsyncFactory
    {
        public UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            IEventLoopsRegistry callbacks);
    }
}