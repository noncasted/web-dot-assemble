using Global.Services.Setup.Service;
using UnityEngine;

namespace Global.Services.Setup.Abstract
{
    public abstract class GlobalServicesConfig : ScriptableObject
    {
        public abstract IGlobalServiceFactory[] GetFactories();
        public abstract IGlobalServiceAsyncFactory[] GetAsyncFactories();
    }
}