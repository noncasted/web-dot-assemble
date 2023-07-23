using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Menu.Main.Controller.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Main.Controller.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuControllerRoutes.ServiceName, menuName = MenuControllerRoutes.ServicePath)]
    public class MenuControllerFactory : ScriptableObject, ILocalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<MenuController>()
                .AsCallbackListener();
        }
    }
}