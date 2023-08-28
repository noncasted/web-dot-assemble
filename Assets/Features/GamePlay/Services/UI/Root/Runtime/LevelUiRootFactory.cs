using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using GamePlay.Services.UI.Root.Common;
using Global.UI.UiStateMachines.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.UI.Root.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelUiRootRoutes.ServiceName,
        menuName = LevelUiRootRoutes.ServicePath)]
    public class LevelUiRootFactory : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] private UiConstraints _constraints;

        public void Create(IDependencyRegister builder, ILocalServiceBinder serviceBinder, IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<LevelUiRoot>()
                .WithParameter(_constraints)
                .As<ILevelUiRoot>();
        }
    }
}