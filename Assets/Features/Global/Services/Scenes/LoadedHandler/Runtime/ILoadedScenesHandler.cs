using Common.Architecture.Local.ComposedSceneConfig;
using Cysharp.Threading.Tasks;

namespace Global.Scenes.LoadedHandler.Runtime
{
    public interface ILoadedScenesHandler
    {
        public void OnLoaded(ComposedSceneLoadResult loaded);

        public UniTask Unload();

        public UniTask FinalizeUnloading();
    }
}