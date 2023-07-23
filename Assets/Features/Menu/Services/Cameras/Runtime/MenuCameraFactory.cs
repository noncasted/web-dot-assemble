using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Menu.Services.Cameras.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Services.Cameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuCameraRoutes.ServiceName, menuName = MenuCameraRoutes.ServicePath)]
    public class MenuCameraFactory : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] private Camera _prefab;
        
        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            var position = new Vector3(0f, 0f, -10f);
            var camera = Instantiate(_prefab, position, Quaternion.identity);
            camera.name = "MenuCamera";

            serviceBinder.AddToModules(camera.gameObject);
        }
    }
}