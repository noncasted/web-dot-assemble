using System;
using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.Local.Abstract
{
    public interface ILocalCallbacks : ICallbackRegister
    {
        void AddInitCallback<T>(Action<T> invoker, int order);
        void AddInitAsyncCallback<T>(Func<T, UniTask> invoker, int order);
        
        void AddLoadingCompletionCallback<T>(Action<T> invoker, int order);
        void AddLoadingCompletionAsyncCallback<T>(Func<T, UniTask> invoker, int order);
        
        void AddDestroyCallback<T>(Action<T> invoker, int order);
        void AddDestroyAsyncCallback<T>(Func<T, UniTask> invoker, int order);
    }
}