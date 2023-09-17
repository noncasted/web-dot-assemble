using Common.Architecture.DiContainer.Abstract;
using Global.Options.Implementations;
using Global.Scenes.Operations.Abstract;
using Global.Scenes.Operations.Addressable;
using Global.Scenes.Operations.Common;
using Global.Scenes.Operations.Logs;
using Global.Scenes.Operations.Native;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Scenes.Operations.Root
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
            
            if (options.UseAddressables == true)
            {
                builder.Register<AddressablesSceneLoader>()
                    .As<ISceneLoader>();

                builder.Register<AddressablesScenesUnloader>()
                    .As<ISceneUnloader>();
            }
            else
            {
                builder.Register<NativeSceneLoader>()
                    .As<ISceneLoader>();

                builder.Register<NativeSceneUnloader>()
                    .As<ISceneUnloader>();
            }
            
            builder.Register<ScenesFlowLogger>()
                .WithParameter(_logSettings);
        }
    }
}