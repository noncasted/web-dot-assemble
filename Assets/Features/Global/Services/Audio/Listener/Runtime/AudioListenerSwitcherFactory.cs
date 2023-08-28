using Common.Architecture.DiContainer.Abstract;
using Global.Audio.Listener.Common;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Audio.Listener.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ListenerRoutes.ServiceName, menuName = ListenerRoutes.ServicePath)]
    public class AudioListenerSwitcherFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] private AudioListenerSwitcher _prefab;
        
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            var switcher = Instantiate(_prefab);
            switcher.name = "AudioListener";
            serviceBinder.AddToModules(switcher);

            builder.RegisterComponent(switcher)
                .As<IAudioListenerSwitcher>();
        }
    }
}