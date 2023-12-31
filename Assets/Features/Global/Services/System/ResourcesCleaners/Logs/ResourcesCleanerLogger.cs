﻿using Internal.Services.Loggers.Runtime;

namespace Global.System.ResourcesCleaners.Logs
{
    public class ResourcesCleanerLogger
    {
        public ResourcesCleanerLogger(ILogger logger, ResourcesCleanerLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private const string _header = "ScenesFlow";

        private readonly ILogger _logger;
        private readonly ResourcesCleanerLogSettings _settings;

        public void OnCleaned()
        {
            if (_settings.IsAvailable(ResourcesCleanerLogType.Cleaned) == false)
                return;

            _logger.Log("Resources are cleaned", _settings.LogParameters);
        }
    }
}