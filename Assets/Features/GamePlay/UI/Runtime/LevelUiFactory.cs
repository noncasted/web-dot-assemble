using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Features.GamePlay.UI.Common;
using UnityEngine;

namespace Features.GamePlay.UI.Runtime
{
    [CreateAssetMenu(fileName = LevelUIRoutes.ServiceName,
        menuName = LevelUIRoutes.ServicePath)]
    public class LevelUiFactory : ScriptableObject, ILocalServiceFactory
    {
        public void Create(IDependencyRegister builder, ILocalServiceBinder serviceBinder, IEventLoopsRegistry loopsRegistry)
        {
        }
    }
}