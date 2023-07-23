using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Menu.Loop.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Loop.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuLoopRoutes.MockServiceName,
        menuName = MenuLoopRoutes.MockServicePath)]
    public class MockMenuLoopFactory : BaseMenuLoopFactory
    {
        public override void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<MockMenuLoop>()
                .AsCallbackListener();
        }
    }
}