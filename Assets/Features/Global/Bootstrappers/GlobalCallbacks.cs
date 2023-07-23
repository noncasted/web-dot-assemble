using System.Collections.Generic;
using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Services.Setup.Service;
using Global.Services.Setup.Service.Callbacks;

namespace Global.Bootstrappers
{
    public class GlobalCallbacks : IGlobalCallbacks, ICallbackRegister, IDestroyCallbacksProvider
    {
        private readonly List<IGlobalAsyncAwakeListener> _asyncAwakes = new();
        private readonly List<IGlobalAsyncBootstrapListener> _asyncBootstraps = new();
        private readonly List<IGlobalAwakeListener> _awakes = new();
        private readonly List<IGlobalBootstrapListener> _bootstraps = new();
        private readonly List<IGlobalInternalCallbackLoop> _internalLoops = new();
        
        private readonly List<IGlobalDestroyListener> _destroyListeners = new();

        public IReadOnlyList<IGlobalDestroyListener> DestroyListeners => _destroyListeners;

        public void Listen(object service)
        {
            if (service is IGlobalAwakeListener awake)
                _awakes.Add(awake);

            if (service is IGlobalAsyncAwakeListener asyncAwake)
                _asyncAwakes.Add(asyncAwake);

            if (service is IGlobalBootstrapListener bootstrap)
                _bootstraps.Add(bootstrap);

            if (service is IGlobalAsyncBootstrapListener asyncBootstrap)
                _asyncBootstraps.Add(asyncBootstrap);
            
            if (service is IGlobalDestroyListener destroyListener)
                _destroyListeners.Add(destroyListener);
        }

        public void AddInternalCallbackLoop(IGlobalInternalCallbackLoop callbackLoop)
        {
            _internalLoops.Add(callbackLoop);
        }

        public async UniTask InvokeFlowCallbacks()
        {
            var internalLoops = new UniTask[_internalLoops.Count];

            for (var i = 0; i < _internalLoops.Count; i++)
                internalLoops[i] = _internalLoops[i].Run();

            await UniTask.WhenAll(internalLoops);

            foreach (var awake in _awakes)
                awake.OnAwake();

            var asyncAwakes = new UniTask[_asyncAwakes.Count];

            for (var i = 0; i < _asyncAwakes.Count; i++)
                asyncAwakes[i] = _asyncAwakes[i].OnAwakeAsync();

            await UniTask.WhenAll(asyncAwakes);

            foreach (var bootstrap in _bootstraps)
                bootstrap.OnBootstrapped();

            var asyncBootstraps = new UniTask[_asyncBootstraps.Count];

            for (var i = 0; i < _asyncBootstraps.Count; i++)
                asyncBootstraps[i] = _asyncBootstraps[i].OnBootstrapAsync();

            await UniTask.WhenAll(asyncBootstraps);
        }
    }
}