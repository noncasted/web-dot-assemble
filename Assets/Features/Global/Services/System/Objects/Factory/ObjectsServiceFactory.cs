using Common.Architecture.DiContainer.Abstract;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Global.Setup.Service;
using Global.System.Objects.Abstract;
using Global.System.Objects.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.Objects.Factory
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ObjectsRoutes.ServiceName,
        menuName = ObjectsRoutes.ServicePath)]
    public class ObjectsFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] private ObjectAsset<GameObject> _objectAsset;

        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            
        }
    }
}