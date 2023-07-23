using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;

namespace GamePlay.Common.SceneBootstrappers.Runtime
{
    public interface ISceneBootstrapper
    {
        void Build(IDependencyRegister builder, IEventLoopsRegistry callbacks);
    }
}