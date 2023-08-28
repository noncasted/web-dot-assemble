using System;
using Cysharp.Threading.Tasks;

namespace Global.Services.Setup.Service
{
    public interface IGlobalCallbacks
    {
        void AddInitCallback<T>(Action<T> invoker, int order);
        void AddInitAsyncCallback<T>(Func<T, UniTask> invoker, int order);
        
        void AddDestroyCallback<T>(Action<T> invoker, int order);
        void AddDestroyAsyncCallback<T>(Func<T, UniTask> invoker, int order);

        void Listen(object listener);
    }
}