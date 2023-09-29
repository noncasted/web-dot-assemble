using Internal.Services.Options.Runtime;

namespace Common.Architecture.Local.Abstract
{
    public interface ILocalUtils
    {
        ILocalServiceBinder ServiceBinder { get; }
        ILocalCallbacks LoopsRegistry { get; }
        IOptions Options { get; }
    }
}