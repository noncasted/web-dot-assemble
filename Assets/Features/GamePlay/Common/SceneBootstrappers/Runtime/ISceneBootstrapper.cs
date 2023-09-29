using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;

namespace GamePlay.Common.SceneBootstrappers.Runtime
{
    public interface ISceneBootstrapper
    {
        void Build(IServiceCollection builder, ILocalCallbacks callbacks);
    }
}