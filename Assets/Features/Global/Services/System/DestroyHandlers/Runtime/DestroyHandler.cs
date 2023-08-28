using Global.Setup.Service;
using UnityEngine;
using VContainer;

namespace Global.System.DestroyHandlers.Runtime
{
    [DisallowMultipleComponent]
    public class DestroyHandler : MonoBehaviour
    {
        [Inject]
        private void Construct(IDestroyCallbacksProvider callbacksProvider)
        {
            _callbacksProvider = callbacksProvider;
        }
        
        private IDestroyCallbacksProvider _callbacksProvider;
        
        private void OnDestroy()
        {
            foreach (var callback in _callbacksProvider.DestroyListeners)
                callback.InvokeAsync().GetAwaiter().GetResult();
        }
    }
}