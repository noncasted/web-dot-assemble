using Common.Architecture.Local.Abstract;
using Internal.Services.Options.Runtime;

namespace Common.Architecture.Local.ComposedSceneConfig
{   
    public class LocalUtils : ILocalUtils
    {
        public LocalUtils(ILocalServiceBinder serviceBinder, ILocalCallbacks localCallbacks, IOptions options)
        {
            _serviceBinder = serviceBinder;
            _localCallbacks = localCallbacks;
            _options = options;
        }
     
        private readonly ILocalServiceBinder _serviceBinder;
        private readonly ILocalCallbacks _localCallbacks;
        private readonly IOptions _options;

        public ILocalServiceBinder ServiceBinder => _serviceBinder;
        public ILocalCallbacks LoopsRegistry => _localCallbacks;
        public IOptions Options => _options;
    }
}