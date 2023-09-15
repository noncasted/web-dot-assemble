using Cysharp.Threading.Tasks;
using Global.GameLoops.Runtime;
using Global.Setup.Abstract;
using Global.Setup.Scope;
using Global.Setup.Service;
using Global.Setup.Service.Callbacks;
using NaughtyAttributes;
using UnityEngine;
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
        [SerializeField] private Options.Runtime.Options _options;
        [SerializeField] private GameLoopFactory _gameLoop;
        [SerializeField] private GlobalServicesConfig _services;

        private void Awake()
        {
            Bootstrap().Forget();
        }

        private async UniTaskVoid Bootstrap()
        {
            var sceneLoader = new GlobalSceneLoader();
            var servicesScene = await sceneLoader.LoadAsync(_servicesScene);
            var binder = new GlobalServiceBinder(servicesScene);
            var callbacks = new GlobalCallbacks();
            var builder = new ContainerBuilder();
            var utils = new GlobalUtils(binder, callbacks, _options);
            var scope = CreateScope(binder);

            _options.Setup();
            
            AddCallbacks(callbacks);
            await CreateServices(builder, sceneLoader, _services, utils, _gameLoop, callbacks);
            await BuildContainer(builder, scope, callbacks);

            await callbacks.InvokeFlowCallbacks();

            var gameLoop = scope.Container.Resolve<IGameLoop>();

            gameLoop.OnBootstrapped();
            gameLoop.Start();
        }

        private GlobalScope CreateScope(GlobalServiceBinder binder)
        {
            var scope = Instantiate(_scope);
            scope.IsRoot = true;

            binder.AddToModules(scope);

            return scope;
        }

        private void AddCallbacks(GlobalCallbacks callbacks)
        {
            callbacks.AddInitCallback<IGlobalAwakeListener>(listener => listener.OnAwake(), 0);
            callbacks.AddInitAsyncCallback<IGlobalAsyncAwakeListener>(listener => listener.OnAwakeAsync(), 1);
            callbacks.AddInitCallback<IGlobalBootstrapListener>(listener => listener.OnBootstrapped(), 2);
            callbacks.AddInitAsyncCallback<IGlobalAsyncBootstrapListener>(listener => listener.OnBootstrapAsync(), 3);

            callbacks.AddDestroyCallback<IGlobalDestroyListener>(listener => listener.OnDestroy(), 0);
        }

        private async UniTask CreateServices(
            ContainerBuilder builder,
            GlobalSceneLoader sceneLoader,
            GlobalServicesConfig servicesConfig,
            GlobalUtils utils,
            GameLoopFactory gameLoopFactory,
            GlobalCallbacks callbacks)
        {
            var factories = servicesConfig.GetFactories();
            var asyncFactories = servicesConfig.GetAsyncFactories();

            foreach (var factory in factories)
                factory.Create(builder, utils);

            var asyncFactoriesTasks = new UniTask[asyncFactories.Length];

            for (var i = 0; i < asyncFactories.Length; i++)
                asyncFactoriesTasks[i] = asyncFactories[i].Create(builder, sceneLoader, utils);

            await UniTask.WhenAll(asyncFactoriesTasks);

            builder.RegisterInstance<IDestroyCallbacksProvider>(callbacks);
            builder.RegisterInstance(utils.Options);
            gameLoopFactory.Create(builder, utils);
        }

        private async UniTask BuildContainer(
            ContainerBuilder globalBuilder,
            LifetimeScope scope,
            GlobalCallbacks callbacks)
        {
            using (LifetimeScope.Enqueue(OnConfiguration))
            {
                await UniTask.Create(async () => scope.Build());
            }

            void OnConfiguration(IContainerBuilder builder)
            {
                globalBuilder.RegisterAll(builder);
            }

            globalBuilder.ResolveAllWithCallbacks(scope.Container, callbacks);
        }
    }
}