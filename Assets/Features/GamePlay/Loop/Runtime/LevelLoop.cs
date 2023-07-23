using Common.Architecture.Local.Services.Abstract.EventLoops;
using Cysharp.Threading.Tasks;
using GamePlay.Services.LevelCameras.Runtime;

namespace GamePlay.Loop.Runtime
{
    public class LevelLoop : ILocalLoadListener
    {
        public LevelLoop(ILevelCamera levelCamera)
        {
            _levelCamera = levelCamera;
        }

        private readonly ILevelCamera _levelCamera;

        public void OnLoaded()
        {
            Begin().Forget();
        }

        private async UniTask Begin()
        {
        }
    }
}