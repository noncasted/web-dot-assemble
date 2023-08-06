using Cysharp.Threading.Tasks;
using Global.GameLoops.Runtime;
using Global.Services.Setup.Abstract;
using Global.Services.Setup.Scope;
using Global.Services.Setup.Service;
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
            Debug.Log("Starting game bootstrap");

            var binder = new GlobalServiceBinder(servicesScene);
            var sceneLoader = new GlobalSceneLoader();
            var callbacks = new GlobalCallbacks();
            var dependencyRegister = new ContainerBuilder();

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