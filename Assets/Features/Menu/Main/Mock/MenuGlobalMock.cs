using Cysharp.Threading.Tasks;
using Global.Bootstrappers;
using Global.GameLoops.Runtime;
using Global.Services.Scenes.ScenesFlow.Runtime.Abstract;
using Global.Services.Setup.Abstract;
using Global.Services.Setup.Scope;
using Menu.Config.Runtime;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.Architecture.DiContainer.Runtime.ContainerBuilder;

namespace Menu.Main.Mock
{
    [DisallowMultipleComponent]
    public class MenuGlobalMock : MonoBehaviour
    {
        private static bool _isBootstrapped = false;

        [SerializeField] private GlobalScope _scope;
        [SerializeField] private GameLoopFactory _gameLoop;
        [SerializeField] private MenuConfig _menu;
        [SerializeField, Scene]  private string _servicesScene;

        [SerializeField] private GlobalServicesConfig _services;

        private void Awake()
        {
            if (_isBootstrapped == true)
                return;

            _isBootstrapped = true;

            Process().Forget();
        }

        private void OnDestroy()
        {
            _isBootstrapped = false;
        }

        private async UniTask Process()
        {
            await BootstrapGlobal();
            await BootstrapLocal();
        }

        private async UniTask BootstrapGlobal()
        {
            var servicesScene = new Scene();

            SceneManager.sceneLoaded += (scene, _) => { servicesScene = scene; };

            await SceneManager.LoadSceneAsync(_servicesScene, LoadSceneMode.Additive).ToUniTask();
            await UniTask.WaitUntil(() => servicesScene.name == _servicesScene);

            var binder = new GlobalServiceBinder(servicesScene);
            var sceneLoader = new GlobalSceneLoader();
            var callbacks = new GlobalCallbacks();
            var dependencyRegister = new ContainerBuilder();

            _gameLoop.Create(dependencyRegister, binder, callbacks);

            var factories = _services.GetFactories();
            var asyncFactories = _services.GetAsyncFactories();

            foreach (var factory in factories)
                factory.Create(dependencyRegister, binder, callbacks);

            var asyncFactoriesTasks = new UniTask[asyncFactories.Length];

            for (var i = 0; i < asyncFactories.Length; i++)
                asyncFactoriesTasks[i] = asyncFactories[i].Create(dependencyRegister, binder, sceneLoader, callbacks);

            await UniTask.WhenAll(asyncFactoriesTasks);

            using (LifetimeScope.Enqueue(OnConfiguration))
            {
                await UniTask.Create(async () => _scope.Build());
            }

            void OnConfiguration(IContainerBuilder builder)
            {
                dependencyRegister.RegisterAll(builder);
            }

            dependencyRegister.ResolveAllWithCallbacks(_scope.Container, callbacks);
            await callbacks.InvokeFlowCallbacks();

            var gameLoop = _scope.Container.Resolve<IGameLoop>();

            gameLoop.OnBootstrapped();
        }

        private async UniTask BootstrapLocal()
        {
            var result = await _menu.Load(_scope, _scope.Container.Resolve<ISceneLoader>());

            result.OnLoaded();
        }
    }
}