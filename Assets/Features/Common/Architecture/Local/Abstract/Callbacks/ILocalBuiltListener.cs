﻿using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Common.Architecture.Local.Abstract.Callbacks
{
    public interface ILocalBuiltListener
    {
        UniTask OnContainerBuilt(LifetimeScope parent, ICallbackRegister callbacks);
    }
}