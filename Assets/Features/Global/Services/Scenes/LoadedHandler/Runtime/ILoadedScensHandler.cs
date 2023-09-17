using Common.Architecture.Local.ComposedSceneConfig;
using Cysharp.Threading.Tasks;

namespace Global.Scenes.LoadedHandler.Runtime
{
    public interface ILoadedScensHandler
    {
        public void OnLoaded(ComposedSceneLoadResult loaded);

        public UniTask Unload();

        public UniTask FinalizeUnloading();
    }
}