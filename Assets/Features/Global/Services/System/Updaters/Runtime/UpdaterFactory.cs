using Common.Architecture.DiContainer.Abstract;
using Global.Setup.Service;
using Global.System.Updaters.Common;
using Global.System.Updaters.Logs;
using Global.System.Updaters.Runtime.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.Updaters.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = UpdaterRouter.ServiceName,
        menuName = UpdaterRouter.ServicePath)]
    public class UpdaterFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private UpdaterLogSettings _logSettings;
        [SerializeField] [Indent] private Updater _prefab;

        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            var updater = Instantiate(_prefab);
            updater.name = "Updater";

            builder.Register<UpdaterLogger>()
                .WithParameter(_logSettings);

            builder.RegisterComponent(updater)
                .As<IUpdater>()
                .As<IUpdateSpeedModifier>()
                .As<IUpdateSpeedSetter>()
                .AsSelfResolvable()
                .AsCallbackListener();

            utils.Binder.AddToModules(updater);
        }
    }
}