using Common.Architecture.Local.Abstract;
using Global.Options.Runtime;

namespace Common.Architecture.Local.ComposedSceneConfig
{   
    public class LocalUtils : ILocalUtils
    {
        public LocalUtils(ILocalServiceBinder serviceBinder, IEventLoopsRegistry eventLoopsRegistry, IOptions options)
        {
            _serviceBinder = serviceBinder;
            _eventLoopsRegistry = eventLoopsRegistry;
            _options = options;
        }
     
        private readonly ILocalServiceBinder _serviceBinder;
        private readonly IEventLoopsRegistry _eventLoopsRegistry;
        private readonly IOptions _options;

        public ILocalServiceBinder ServiceBinder => _serviceBinder;
        public IEventLoopsRegistry LoopsRegistry => _eventLoopsRegistry;
        public IOptions Options => _options;
    }
}