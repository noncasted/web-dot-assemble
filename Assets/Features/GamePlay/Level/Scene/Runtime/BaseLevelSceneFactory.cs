using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Cysharp.Threading.Tasks;
using Global.Scenes.Operations.Abstract;
using UnityEngine;

namespace GamePlay.Level.Scene.Runtime
{
    public abstract class BaseLevelSceneFactory : ScriptableObject, ILocalServiceAsyncFactory
    {
        public abstract UniTask Create(IDependencyRegister builder,ISceneLoader sceneLoader, ILocalUtils utils);
    }
}