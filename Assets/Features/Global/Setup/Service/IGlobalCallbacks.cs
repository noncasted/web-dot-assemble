using System;
using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;

namespace Global.Setup.Service
{
    public interface IGlobalCallbacks : ICallbackRegister
    {
        void AddInitCallback<T>(Action<T> invoker, int order);
        void AddInitAsyncCallback<T>(Func<T, UniTask> invoker, int order);
        
        void AddDestroyCallback<T>(Action<T> invoker, int order);
        void AddDestroyAsyncCallback<T>(Func<T, UniTask> invoker, int order);
    }
}