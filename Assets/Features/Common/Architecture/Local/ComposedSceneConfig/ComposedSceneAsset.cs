using System.Collections.Generic;
using Common.Architecture.Local.Abstract;
using Common.Architecture.Local.Abstract.Callbacks;
using Cysharp.Threading.Tasks;
using Global.Options.Runtime;
using Global.Scenes.Operations.Abstract;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.Architecture.DiContainer.Runtime.ContainerBuilder;

namespace Common.Architecture.Local.ComposedSceneConfig
{
    public abstract class ComposedSceneAsset : ScriptableObject
    {
        [SerializeField] private ComposedScenesConfig _config;

        public async UniTask<ComposedSceneLoadResult> Load(
            LifetimeScope parent,
            ISceneLoader globalSceneLoader,
            IOptions options)
        {
            var scopePrefab = GetScopePrefab();
            var scope = Instantiate(scopePrefab);

            var composedSceneLoader = new ComposedSceneLoader(globalSceneLoader);
            var serviceBinder = await CreateServiceBinder(composedSceneLoader);
            serviceBinder.AddToModules(scope);

            var callbacks = new LocalCallbacks();
            var utils = new LocalUtils(serviceBinder, callbacks, options);
            var builder = new ContainerBuilder();

            AddCallbacks(callbacks, scope);
            await CreateServices(builder, composedSceneLoader, utils);
            await BuildContainer(builder, scope, parent, callbacks);

            await callbacks.InitCallbacks.Run();

            return new ComposedSceneLoadResult(
                composedSceneLoader.Results,
                callbacks.DestroyCallbacks,
                callbacks.LoadingCompletionListeners,
                scope);
        }

        private async UniTask<LocalServiceBinder> CreateServiceBinder(ComposedSceneLoader sceneLoader)
        {
            var loadServicesScene = await sceneLoader.Load(_config.ServicesScene);
            var servicesScene = loadServicesScene.Scene;
            var transformer = new LocalServiceTransformer(servicesScene);
            var serviceBinder = new LocalServiceBinder(transformer);

            return serviceBinder;
        }

        private void AddCallbacks(ILocalCallbacks callbacks, LifetimeScope scope)
        {
            callbacks.AddInitCallback<ILocalAwakeListener>(
                listener => listener.OnAwake(), 0);
            callbacks.AddInitAsyncCallback<ILocalAsyncAwakeListener>(
                listener => listener.OnAwakeAsync(), 1);
            callbacks.AddInitCallback<ILocalBootstrappedListener>(
                listener => listener.OnBootstrapped(), 2);
            callbacks.AddInitAsyncCallback<ILocalAsyncBootstrappedListener>(
                listener => listener.OnBootstrappedAsync(), 3);
            callbacks.AddInitAsyncCallback<ILocalBuiltListener>(
                listener => listener.OnContainerBuilt(scope, callbacks), 4);
            callbacks.AddInitCallback<ILocalSwitchListener>(
                listener => listener.OnEnabled(), 5);

            callbacks.AddLoadingCompletionCallback<ILocalLoadListener>(
                listener => listener.OnLoaded(), 0);

            callbacks.AddDestroyCallback<ILocalDisableListener>(
                listener => listener.OnDisabled(), 0);
        }

        private async UniTask CreateServices(
            ContainerBuilder builder,
            ComposedSceneLoader sceneLoader,
            LocalUtils utils)
        {
            var factories = GetFactories();
            var asyncFactories = GetAsyncFactories();

            foreach (var factory in factories)
                factory.Create(builder, utils);

            var asyncFactoriesTasks = new List<UniTask>();

            foreach (var service in asyncFactories)
            {
                var task = service.Create(builder, sceneLoader, utils);
                asyncFactoriesTasks.Add(task);
            }

            await UniTask.WhenAll(asyncFactoriesTasks);
        }

        private async UniTask BuildContainer(
            ContainerBuilder builder,
            LifetimeScope scope,
            LifetimeScope parent,
            LocalCallbacks callbacks)
        {
            using (LifetimeScope.EnqueueParent(parent))
            {
                using (LifetimeScope.Enqueue(Register))
                {
                    await UniTask.Create(async () => scope.Build());
                }
            }

            void Register(IContainerBuilder container)
            {
                container.Register<LocalScopeProvider>(Lifetime.Singleton)
                    .As<ILocalScopeProvider>()
                    .WithParameter(scope);

                builder.RegisterAll(container);
            }

            builder.ResolveAllWithCallbacks(scope.Container, callbacks);
        }

        protected abstract ILocalServiceFactory[] GetFactories();
        protected abstract ILocalServiceAsyncFactory[] GetAsyncFactories();
        protected abstract LifetimeScope GetScopePrefab();
    }
}