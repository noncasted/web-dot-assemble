using Common.Architecture.DiContainer.Abstract;
using Global.Localizations.Common;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Localizations.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LocalizationRoutes.ServiceName, menuName = LocalizationRoutes.ServicePath)]
    public class LocalizationAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private LocalizationStorage _storage;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<Localization>()
                .WithParameter<ILocalizationStorage>(_storage)
                .AsCallbackListener();
        }
    }
}