using Common.Architecture.Mocks;
using Cysharp.Threading.Tasks;
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
            var menu= await _menu.Load(result.Parent, result.Resolver.Resolve<ISceneLoader>());

            result.RegisterLoadedScene(menu);
        }
    }
}