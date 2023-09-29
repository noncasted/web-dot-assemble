using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Quests.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Quests.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = QuestsRoutes.ServiceName,
        menuName = QuestsRoutes.ServicePath)]
    public class QuestsServiceFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<Quests>()
                .As<IQuests>();
        }
    }
}