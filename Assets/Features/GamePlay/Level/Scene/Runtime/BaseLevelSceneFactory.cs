using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Cysharp.Threading.Tasks;
using Internal.Services.Scenes.Abstract;
using UnityEngine;

namespace GamePlay.Level.Scene.Runtime
{
    public abstract class BaseLevelSceneFactory : ScriptableObject, ILocalServiceAsyncFactory
    {
        public abstract UniTask Create(IServiceCollection builder,ISceneLoader sceneLoader, ILocalUtils utils);
    }
}