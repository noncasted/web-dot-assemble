using Global.Options.Runtime;

namespace Common.Architecture.Local.Abstract
{
    public interface ILocalUtils
    {
        ILocalServiceBinder ServiceBinder { get; }
        IEventLoopsRegistry LoopsRegistry { get; }
        IOptions Options { get; }
    }
}