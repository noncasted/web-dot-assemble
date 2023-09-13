using Common.Architecture.DiContainer.Abstract;
using Global.Options.Implementations;
using Global.Scenes.ScenesFlow.Common;
using Global.Scenes.ScenesFlow.Logs;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Scenes.ScenesFlow.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ScenesFlowRoutes.ServiceName,
        menuName = ScenesFlowRoutes.ServicePath)]
    public class ScenesFlowFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private ScenesFlowLogSettings _logSettings;

        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            var options = utils.Options.GetOptions<AssetsOptions>();

            builder.Register<ScenesFlowLogger>()
                .WithParameter(_logSettings);
            
            if (options.UseAddressables == true)
            {
                builder.Register<AddressablesSceneLoader>()
                    .As<ISceneLoader>();

                builder.Register<AddressablesScenesUnloader>()
                    .As<ISceneUnloader>();
            }
            else
            {
                builder.Register<DefaultScenesLoader>()
                    .As<ISceneLoader>();

                builder.Register<DefaultScenesUnloader>()
                    .As<ISceneUnloader>();
            }
        }
    }
}