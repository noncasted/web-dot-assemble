using Common.Architecture.DiContainer.Abstract;
using GamePlay.Common.SceneObjects.Common;
using GamePlay.Common.SceneObjects.Logs;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Common.SceneObjects.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SceneObjectsRoutes.ServiceName,
        menuName = SceneObjectsRoutes.ServicePath)]
    public class SceneObjectsAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] private SceneObjectLogSettings _logSettings;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<SceneObjectLogger>()
                .WithParameter(_logSettings);
        }
    }
}