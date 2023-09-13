using Common.Architecture.DiContainer.Abstract;
using Global.Audio.Player.Common;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Audio.Player.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AudioRoutes.ServiceName,
        menuName = AudioRoutes.ServicePath)]
    public class SoundsPlayerFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] private SoundState _state;
        [SerializeField] private SoundsPlayer _prefab;

        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            var player = Instantiate(_prefab);
            player.name = "SoundsPlayer";

            var trigger = player.GetComponent<SoundsTrigger>();

            builder.RegisterInstance(_state);

            builder.RegisterComponent(player)
                .As<IVolumeSetter>()
                .AsCallbackListener();

            utils.Callbacks.Listen(trigger);
            utils.Binder.AddToModules(player);
        }
    }
}