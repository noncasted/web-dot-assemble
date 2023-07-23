using System;
using Cysharp.Threading.Tasks;
using Global.Services.System.ResourcesCleaners.Logs;

namespace Global.Services.System.ResourcesCleaners.Runtime
{
    public class ResourcesCleaner : IResourcesCleaner
    {
        public ResourcesCleaner(ResourcesCleanerLogger logger)
        {
            _logger = logger;
        }

        private readonly ResourcesCleanerLogger _logger;

        public async UniTask CleanUp()
        {
            GC.Collect();

            //await Resources.UnloadUnusedAssets();

            _logger.OnCleaned();
        }
    }
}