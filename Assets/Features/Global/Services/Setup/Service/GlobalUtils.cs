using Global.Options.Runtime;

namespace Global.Setup.Service
{
    public class GlobalUtils : IGlobalUtils
    {
        public GlobalUtils(
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks,
            IOptions options)
        {
            _serviceBinder = serviceBinder;
            _callbacks = callbacks;
            _options = options;
        }

        private readonly IGlobalServiceBinder _serviceBinder;
        private readonly IGlobalCallbacks _callbacks;
        private readonly IOptions _options;

        public IGlobalServiceBinder Binder => _serviceBinder;
        public IGlobalCallbacks Callbacks => _callbacks;
        public IOptions Options => _options;
    }
}