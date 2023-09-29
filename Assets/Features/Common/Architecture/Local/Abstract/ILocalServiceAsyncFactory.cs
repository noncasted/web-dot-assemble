using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Internal.Services.Scenes.Abstract;

namespace Common.Architecture.Local.Abstract
{
    public interface ILocalServiceAsyncFactory
    {
        public UniTask Create(IServiceCollection builder, ISceneLoader sceneLoader, ILocalUtils utils);
    }
}