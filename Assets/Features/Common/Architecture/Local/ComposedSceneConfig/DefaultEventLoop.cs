using System;
using System.Collections.Generic;
using Common.Architecture.Local.Services.Abstract.Callbacks;
using Common.Architecture.Local.Services.Abstract.EventLoops;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.Local.ComposedSceneConfig
{
    [Serializable]
    public class DefaultEventLoop : IEventLoop
    {
        private readonly List<ILocalAsyncAwakeListener> _asyncAwakes = new();
        private readonly List<ILocalAwakeListener> _awakes = new();
        private readonly List<ILocalAsyncBootstrappedListener> _asyncBootstraps = new();
        private readonly List<ILocalBootstrappedListener> _bootstraps = new();
        private readonly List<ILocalSwitchListener> _switches = new();

        public void Clear()
        {
            _asyncAwakes.Clear();
            _awakes.Clear();
            _asyncBootstraps.Clear();
            _bootstraps.Clear();
            _switches.Clear();
        }

        public void Listen(object service)
        {
            if (service is ILocalAwakeListener awake)
                _awakes.Add(awake);

            if (service is ILocalAsyncAwakeListener asyncAwake)
                _asyncAwakes.Add(asyncAwake);

            if (service is ILocalSwitchListener switchCallback)
                _switches.Add(switchCallback);

            if (service is ILocalBootstrappedListener bootstrap)
                _bootstraps.Add(bootstrap);

            if (service is ILocalAsyncBootstrappedListener asyncBootstrap)
                _asyncBootstraps.Add(asyncBootstrap);
        }

        public async UniTask Run()
        {
            InvokeAwakeCallbacks();
            await InvokeAsyncAwakeCallbacks();
            InvokeEnableCallback();
            await InvokeAsyncBootstrapCallbacks();
            InvokeBootstrapCallbacks();
        }
        
        private void InvokeAwakeCallbacks()
        {
            foreach (var awake in _awakes)
                awake.OnAwake();
        }

        private async UniTask InvokeAsyncAwakeCallbacks()
        {
            var tasks = new UniTask[_asyncAwakes.Count];

            for (var i = 0; i < tasks.Length; i++)
                tasks[i] = _asyncAwakes[i].OnAwakeAsync();

            await UniTask.WhenAll(tasks);
        }

        private void InvokeEnableCallback()
        {
            foreach (var switchListener in _switches)
                switchListener.OnEnabled();
        }

        private void InvokeBootstrapCallbacks()
        {
            foreach (var bootstrap in _bootstraps)
                bootstrap.OnBootstrapped();
        }

        private async UniTask InvokeAsyncBootstrapCallbacks()
        {
            var tasks = new UniTask[_asyncBootstraps.Count];

            for (var i = 0; i < tasks.Length; i++)
                tasks[i] = _asyncBootstraps[i].OnBootstrappedAsync();

            await UniTask.WhenAll(tasks);
        }
    }
}