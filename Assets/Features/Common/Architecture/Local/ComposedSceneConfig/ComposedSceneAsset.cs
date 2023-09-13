using System.Collections.Generic;
using Common.Architecture.Local.Abstract;
using Common.Architecture.Local.Abstract.EventLoops;
using Cysharp.Threading.Tasks;
using Global.Scenes.ScenesFlow.Handling.Data;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.Architecture.DiContainer.Runtime.ContainerBuilder;

namespace Common.Architecture.Local.ComposedSceneConfig
{
    public abstract class ComposedSceneAsset : ScriptableObject
    {
        [SerializeField] private ComposedScenesConfig _config;
        [SerializeReference] private IEventLoop[] _loops;

        public async UniTask<ComposedSceneLoadResult> Load(LifetimeScope parent, ISceneLoader loader)
        {
            var factories = GetFactories();
            var asyncFactories = GetAsyncFactories();

            var sceneLoader = new ComposedSceneLoader(loader);
            var asyncFactoriesTasks = new List<UniTask>();

            var loadServicesScene = await sceneLoader.Load(new EmptySceneLoadData(_config.ServicesScene));
            var servicesScene = loadServicesScene.Scene;
            var transformer = new LocalServiceTransformer(servicesScene);

            var serviceBinder = new LocalServiceBinder(transformer);
            
            var eventLoopsRegistry = new EventLoopsRegistry(_loops);
            eventLoopsRegistry.Clear();
            
            var builder = new ContainerBuilder();

            foreach (var factory in factories)
                factory.Create(builder, serviceBinder, eventLoopsRegistry);

            foreach (var service in asyncFactories)
            {
                var task = service.Create(builder, serviceBinder, sceneLoader, eventLoopsRegistry);
                asyncFactoriesTasks.Add(task);
            }

            await UniTask.WhenAll(asyncFactoriesTasks);

            var scopePrefab = AssignScope();
            var scope = Instantiate(scopePrefab);
            serviceBinder.AddToModules(scope);

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

            builder.ResolveAllWithCallbacks(scope.Container, eventLoopsRegistry);
            
            await eventLoopsRegistry.InvokeLocalBuilt(scope, eventLoopsRegistry);

            await eventLoopsRegistry.Run();

            return new ComposedSceneLoadResult(
                sceneLoader.Results,
                eventLoopsRegistry.DestroyListeners,
                eventLoopsRegistry.LoadListeners,
                scope);
        }

        protected abstract ILocalServiceFactory[] GetFactories();
        protected abstract ILocalServiceAsyncFactory[] GetAsyncFactories();

        protected abstract LifetimeScope AssignScope();
    }
}