using System;
using Cysharp.Threading.Tasks;
using Global.Bootstrappers;
using Global.Services.Setup.Service;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.Architecture.DiContainer.Runtime.ContainerBuilder;
using Object = UnityEngine.Object;

namespace Common.Architecture.Mocks
{
    [Serializable]
    public class GlobalMock
    {
        [SerializeField] private GlobalMockConfig _config;

        public async UniTask<MockBootstrapResult> BootstrapGlobal()
        {
            var servicesScene = new Scene();

            SceneManager.sceneLoaded += (scene, _) => { servicesScene = scene; };

            await SceneManager.LoadSceneAsync(_config.ServicesScene, LoadSceneMode.Additive).ToUniTask();
            await UniTask.WaitUntil(() => servicesScene.name == _config.ServicesScene);

            var binder = new GlobalServiceBinder(servicesScene);
            var sceneLoader = new GlobalSceneLoader();
            var callbacks = new GlobalCallbacks();
            var dependencyRegister = new ContainerBuilder();
            
            var scope = Object.Instantiate(_config.Scope);
            scope.IsRoot = true;
            
            _config.GameLoop.Create(dependencyRegister, binder, callbacks);

            var factories = _config.Services.GetFactories();
            var asyncFactories = _config.Services.GetAsyncFactories();

            dependencyRegister.RegisterInstance<IDestroyCallbacksProvider>(callbacks);
            
            foreach (var factory in factories)
                factory.Create(dependencyRegister, binder, callbacks);

            var asyncFactoriesTasks = new UniTask[asyncFactories.Length];

            for (var i = 0; i < asyncFactories.Length; i++)
                asyncFactoriesTasks[i] = asyncFactories[i].Create(dependencyRegister, binder, sceneLoader, callbacks);

            await UniTask.WhenAll(asyncFactoriesTasks);

            using (LifetimeScope.Enqueue(OnConfiguration))
            {
                await UniTask.Create(async () => scope.Build());
            }

            void OnConfiguration(IContainerBuilder builder)
            {
                dependencyRegister.RegisterAll(builder);
            }

            dependencyRegister.ResolveAllWithCallbacks(scope.Container, callbacks);

            await callbacks.InvokeFlowCallbacks();

            var result = new MockBootstrapResult(scope);

            return result;
        }
    }
}