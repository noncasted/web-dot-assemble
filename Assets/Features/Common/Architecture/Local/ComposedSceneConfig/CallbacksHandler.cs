using System.Collections.Generic;
using System.Linq;
using Common.Architecture.Local.Abstract;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.Local.ComposedSceneConfig
{
    public class CallbacksHandler
    {
        private readonly List<IAsyncCallbackHandler> _callbacks = new();

        public void Add(IAsyncCallbackHandler handler)
        {
            _callbacks.Add(handler);
        }

        public void Listen(object listener)
        {
            foreach (var callbackHandler in _callbacks)
                callbackHandler.Listen(listener);
        }
        
        public async UniTask Run()
        {
            var orderedCallbacks = _callbacks.OrderBy(t => t.Order);

            foreach (var handler in orderedCallbacks)
                await handler.InvokeAsync();
        }
    }
}