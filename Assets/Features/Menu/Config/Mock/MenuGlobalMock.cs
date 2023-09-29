using Common.Architecture.Mocks.Runtime;
using Cysharp.Threading.Tasks;
using Internal.Services.Options.Runtime;
using Internal.Services.Scenes.Abstract;
using Menu.Config.Runtime;
using UnityEngine;
using VContainer;

namespace Menu.Config.Mock
{
    [DisallowMultipleComponent]
    public class MenuGlobalMock : MockBase
    {
        [SerializeField] private MenuConfig _menu;
        [SerializeField] private GlobalMock _mock;
        
        public override async UniTaskVoid Process()
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