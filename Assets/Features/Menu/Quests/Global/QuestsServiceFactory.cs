using Common.Architecture.DiContainer.Abstract;
using Global.Setup.Service;
using Menu.Quests.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Quests.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = QuestsRoutes.ServiceName,
        menuName = QuestsRoutes.ServicePath)]
    public class QuestsServiceFactory : ScriptableObject, IGlobalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<Quests>()
                .As<IQuests>();
        }
    }
}