using System;
using System.Collections.Generic;
using System.Linq;
using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Setup.Service;

namespace Global.Bootstrappers
{
    public class GlobalCallbacks : IGlobalCallbacks, ICallbackRegister, IDestroyCallbacksProvider
    {
        private readonly List<IAsyncCallbackHandler> _initCallbacks = new();
        private readonly List<IAsyncCallbackHandler> _destroyCallbacks = new();

        public IReadOnlyList<IAsyncCallbackHandler> DestroyListeners => _destroyCallbacks;

        public void AddInitCallback<T>(Action<T> invoker, int order)
        {
            var handler = new CallbackHandler<T>(invoker, order);
            _initCallbacks.Add(handler);
        }

        public void AddInitAsyncCallback<T>(Func<T, UniTask> invoker, int order)
        {
            var handler = new AsyncCallbackHandler<T>(invoker, order);
            _initCallbacks.Add(handler);
        }

        public void AddDestroyCallback<T>(Action<T> invoker, int order)
        {
            var handler = new CallbackHandler<T>(invoker, order);
            _destroyCallbacks.Add(handler);
        }

        public void AddDestroyAsyncCallback<T>(Func<T, UniTask> invoker, int order)
        {
            var handler = new AsyncCallbackHandler<T>(invoker, order);
            _destroyCallbacks.Add(handler);
        }

        public void Listen(object service)
        {
            foreach (var callbackHandler in _initCallbacks)
                callbackHandler.Listen(service);
        }

        public async UniTask InvokeFlowCallbacks()
        {
            var orderedCallbacks = _initCallbacks.OrderBy(t => t.Order);

            foreach (var handler in orderedCallbacks)
                await handler.InvokeAsync();
        }
    }
}