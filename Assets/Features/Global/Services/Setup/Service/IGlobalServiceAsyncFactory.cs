using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Services.Setup.Service.Scenes;

namespace Global.Services.Setup.Service
{
    public interface IGlobalServiceAsyncFactory
    {
        public UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks);
    }
}