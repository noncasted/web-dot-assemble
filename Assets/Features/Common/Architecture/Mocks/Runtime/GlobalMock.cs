using System;
using Cysharp.Threading.Tasks;
using Global.Bootstrappers;
using Global.Setup.Service;
using Global.Setup.Service.Callbacks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.Architecture.DiContainer.Runtime.ContainerBuilder;
using Object = UnityEngine.Object;

namespace Common.Architecture.Mocks.Runtime
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
            
            callbacks.AddInitCallback<IGlobalAwakeListener>(listener => listener.OnAwake(), 0);
            callbacks.AddInitAsyncCallback<IGlobalAsyncAwakeListener>(listener => listener.OnAwakeAsync(), 1);
            callbacks.AddInitCallback<IGlobalBootstrapListener>(listener => listener.OnBootstrapped(), 2);
            callbacks.AddInitAsyncCallback<IGlobalAsyncBootstrapListener>(listener => listener.OnBootstrapAsync(), 3);
            
            callbacks.AddDestroyCallback<IGlobalDestroyListener>(listener => listener.OnDestroy(), 0);
            
            var scope = Object.Instantiate(_config.Scope);
            scope.IsRoot = true;
            
            _config.Options.Setup();
            
            var utils = new GlobalUtils(binder, callbacks, _config.Options);

            _config.GameLoop.Create(dependencyRegister, utils);

            var factories = _config.Services.GetFactories();
            var asyncFactories = _config.Services.GetAsyncFactories();

            dependencyRegister.RegisterInstance<IDestroyCallbacksProvider>(callbacks);
            dependencyRegister.RegisterInstance(_config.Options);
            
            foreach (var factory in factories)
                factory.Create(dependencyRegister, utils);

            var asyncFactoriesTasks = new UniTask[asyncFactories.Length];

            for (var i = 0; i < asyncFactories.Length; i++)
                asyncFactoriesTasks[i] = asyncFactories[i].Create(dependencyRegister, sceneLoader, utils);

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