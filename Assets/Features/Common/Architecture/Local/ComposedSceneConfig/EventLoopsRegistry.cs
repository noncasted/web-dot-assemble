using System.Collections.Generic;
using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Common.Architecture.Local.Abstract.Callbacks;
using Common.Architecture.Local.Abstract.EventLoops;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Common.Architecture.Local.ComposedSceneConfig
{
    public class EventLoopsRegistry : IEventLoopsRegistry
    {
        public EventLoopsRegistry(IEventLoop[] eventLoops)
        {
            _eventLoops = eventLoops;
        }

        private readonly IEventLoop[] _eventLoops;

        private readonly List<ILocalDisableListener> _destroyListeners = new();
        private readonly List<ILocalLoadListener> _loadListeners = new();
        private readonly List<ILocalBuiltListener> _buildListeners = new();

        public IReadOnlyList<ILocalDisableListener> DestroyListeners => _destroyListeners;
        public IReadOnlyList<ILocalLoadListener> LoadListeners => _loadListeners;

        public void Clear()
        {
            foreach (var loop in _eventLoops)
                loop.Clear();
        }

        public async UniTask InvokeLocalBuilt(LifetimeScope parent, ICallbackRegister callbacks)
        {
            var tasks = new UniTask[_buildListeners.Count];
            
            for (var i = 0; i < tasks.Length; i++)
                tasks[i] = _buildListeners[i].OnContainerBuilt(parent, callbacks);

            await UniTask.WhenAll(tasks);
        }
        
        public void Listen(object listener)
        {
            foreach (var loop in _eventLoops)
                loop.Listen(listener);
            
            if (listener is ILocalDisableListener disable)
                _destroyListeners.Add(disable);
            
            if (listener is ILocalLoadListener load)
                _loadListeners.Add(load);

            if (listener is ILocalBuiltListener build)
                _buildListeners.Add(build);
        }

        public async UniTask Run()
        {
            foreach (var loop in _eventLoops)
                await loop.Run();
        }
    }
}