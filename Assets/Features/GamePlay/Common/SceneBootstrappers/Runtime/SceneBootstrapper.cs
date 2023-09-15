﻿using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Common.Architecture.Local.Abstract.Callbacks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Common.SceneBootstrappers.Runtime
{
    [DisallowMultipleComponent]
    public class SceneBootstrapper : 
        MonoBehaviour, 
        ISceneBootstrapper, 
        ISceneComponentBuildersStorage,
        ILocalBuiltListener
    {
        [SerializeField] private SceneComponentRegister[] _registers;
        [SerializeField] private SceneComponentBuilder[] _builders;
        
        public void Build(IDependencyRegister builder, ILocalCallbacks callbacks)
        {
            foreach (var register in _registers)
                register.Register(builder);

            callbacks.Listen(this);
        }

        public void SetTargets(SceneComponentRegister[] registers, SceneComponentBuilder[] builders)
        {
            _registers = registers;
            _builders = builders;
        }

        public async UniTask OnContainerBuilt(LifetimeScope parent, ICallbackRegister callbacks)
        {
            var tasks = new UniTask[_builders.Length];
            
            for (var i = 0; i < tasks.Length; i++)
                tasks[i] = _builders[i].Build(parent, callbacks);

            await UniTask.WhenAll(tasks);
        }
    }
}