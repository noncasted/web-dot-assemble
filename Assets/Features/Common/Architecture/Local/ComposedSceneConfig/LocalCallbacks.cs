using System;
using Common.Architecture.Local.Abstract;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.Local.ComposedSceneConfig
{
    public class LocalCallbacks : ILocalCallbacks
    {
        private readonly CallbacksHandler _initCallbacks = new();
        private readonly CallbacksHandler _loadingCompletionCallbacks = new();
        private readonly CallbacksHandler _destroyCallbacks = new();
        
        public CallbacksHandler InitCallbacks => _initCallbacks;
        public CallbacksHandler LoadingCompletionListeners => _loadingCompletionCallbacks;
        public CallbacksHandler DestroyCallbacks => _destroyCallbacks;

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

        public void AddLoadingCompletionCallback<T>(Action<T> invoker, int order)
        {
            var handler = new CallbackHandler<T>(invoker, order);
            _loadingCompletionCallbacks.Add(handler);
        }

        public void AddLoadingCompletionAsyncCallback<T>(Func<T, UniTask> invoker, int order)
        {
            var handler = new AsyncCallbackHandler<T>(invoker, order);
            _loadingCompletionCallbacks.Add(handler);
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
            _initCallbacks.Listen(service);
            _loadingCompletionCallbacks.Listen(service);
            _destroyCallbacks.Listen(service);
        }
    }
}