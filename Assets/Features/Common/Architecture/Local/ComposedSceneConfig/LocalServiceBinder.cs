using Common.Architecture.Local.Abstract;
using UnityEngine;

namespace Common.Architecture.Local.ComposedSceneConfig
{
    public class LocalServiceBinder : ILocalServiceBinder
    {
        public LocalServiceBinder(LocalServiceTransformer transformer)
        {
            _serviceTransformer = transformer;
        }

        private readonly LocalServiceTransformer _serviceTransformer;

        public void AddToModules(GameObject service)
        {
            _serviceTransformer.AddService(service);
        }

        public void AddToModules(MonoBehaviour service)
        {
            _serviceTransformer.AddService(service.gameObject);
        }
    }
}