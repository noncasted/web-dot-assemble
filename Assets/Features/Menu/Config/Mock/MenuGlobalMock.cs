using Common.Architecture.Mocks;
using Cysharp.Threading.Tasks;
using Global.Options.Runtime;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using Menu.Config.Runtime;
using UnityEngine;
using VContainer;

namespace Menu.Config.Mock
{
    [DisallowMultipleComponent]
    public class MenuGlobalMock : MonoBehaviour
    {
        [SerializeField] private MenuConfig _menu;
        [SerializeField] private GlobalMock _mock;
        
        private void Awake()
        {
            Process().Forget();
        }

        private async UniTask Process()
        {
            var result = await _mock.BootstrapGlobal();
            await BootstrapLocal(result);
        }

        private async UniTask BootstrapLocal(MockBootstrapResult result)
        {
            var sceneLoader = result.Resolver.Resolve<ISceneLoader>();
            var options = result.Resolver.Resolve<IOptions>();
            var menu= await _menu.Load(result.Parent, sceneLoader, options);

            await result.RegisterLoadedScene(menu);
        }
    }
}