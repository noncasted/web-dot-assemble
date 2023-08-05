using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Menu.Collections.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Collections.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CollectionsRoutes.ControllerName,
        menuName = CollectionsRoutes.ControllerPath)]
    public class CollectionsUIFactory : ScriptableObject, ILocalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<AvatarCollectionsController>()
                .As<IAvatarCollectionsController>();
        }
    }
}