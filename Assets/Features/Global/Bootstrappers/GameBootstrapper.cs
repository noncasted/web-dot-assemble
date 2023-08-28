using Cysharp.Threading.Tasks;
using Global.GameLoops.Runtime;
using Global.Setup.Abstract;
using Global.Setup.Scope;
using Global.Setup.Service;
using Global.Setup.Service.Callbacks;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.Architecture.DiContainer.Runtime.ContainerBuilder;

namespace Global.Bootstrappers
{
    [DisallowMultipleComponent]
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private GlobalScope _scope;
        [SerializeField] [Scene] private string _servicesScene;

        [SerializeField] private GameLoopFactory _gameLoop;
        [SerializeField] private GlobalServicesConfig _services;

        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;

            SceneManager.LoadScene(_servicesScene, LoadSceneMode.Additive);

            void OnSceneLoaded(Scene scene, LoadSceneMode mode)
            {
                if (scene.name != _servicesScene)
                    return;

                SceneManager.sceneLoaded -= OnSceneLoaded;

                Bootstrap(scene).Forget();
            }
        }

        private async UniTaskVoid Bootstrap(Scene servicesScene)
        {
            var binder = new GlobalServiceBinder(servicesScene);
            var sceneLoader = new GlobalSceneLoader();
            var callbacks = new GlobalCallbacks();
            var dependencyRegister = new ContainerBuilder();
            
            callbacks.AddInitCallback<IGlobalAwakeListener>(listener => listener.OnAwake(), 0);
            callbacks.AddInitAsyncCallback<IGlobalAsyncAwakeListener>(listener => listener.OnAwakeAsync(), 1);
            callbacks.AddInitCallback<IGlobalBootstrapListener>(listener => listener.OnBootstrapped(), 2);
            callbacks.AddInitAsyncCallback<IGlobalAsyncBootstrapListener>(listener => listener.OnBootstrapAsync(), 3);
            
            callbacks.AddDestroyCallback<IGlobalDestroyListener>(listener => listener.OnDestroy(), 0);

            var factories = _services.GetFactories();
            var asyncFactories = _services.GetAsyncFactories();

            dependencyRegister.RegisterInstance<IDestroyCallbacksProvider>(callbacks);

            foreach (var factory in factories)
                factory.Create(dependencyRegister, binder, callbacks);

            var asyncFactoriesTasks = new UniTask[asyncFactories.Length];

            for (var i = 0; i < asyncFactories.Length; i++)
                asyncFactoriesTasks[i] = asyncFactories[i].Create(dependencyRegister, binder, sceneLoader, callbacks);

            await UniTask.WhenAll(asyncFactoriesTasks);

            _gameLoop.Create(dependencyRegister, binder, callbacks);

            var scope = Instantiate(_scope);
            scope.IsRoot = true;

            binder.AddToModules(scope);

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

            var gameLoop = scope.Container.Resolve<IGameLoop>();

            gameLoop.OnBootstrapped();
            gameLoop.Start();
        }
    }
}