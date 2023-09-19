using Common.Architecture.DiContainer.Abstract;
using Common.UI.Extended.Common;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Common.UI.Extended.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ExtendedRoutes.ServiceName,
        menuName = ExtendedRoutes.ServicePath)]
    public class ExtendedFactory : ScriptableObject, IGlobalServiceFactory
    {   
        public void Create(
            IDependencyRegister builder,
            IGlobalUtils utils)
        {
        }
    }
}