using Global.Options.Runtime;

namespace Global.Setup.Service
{
    public interface IGlobalUtils
    {
        IGlobalServiceBinder Binder { get; }
        IGlobalCallbacks Callbacks { get; }
        IOptions Options { get; }
    }
}