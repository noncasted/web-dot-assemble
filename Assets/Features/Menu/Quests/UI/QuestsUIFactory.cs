using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Quests.Common;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Quests.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = QuestsRoutes.ControllerName,
        menuName = QuestsRoutes.ControllerPath)]
    public class QuestsUIFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<QuestsController>()
                .As<IQuestsController>()
                .AsTab<QuestsController>(_tabDefinition)
                .AsSelfResolvable();
        }
    }
}