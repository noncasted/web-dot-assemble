using Common.Architecture.Local.Abstract.EventLoops;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.Local.Abstract.Callbacks
{
    public interface ILocalAsyncBootstrappedListener : IEventBase
    {
        UniTask OnBootstrappedAsync();
    }
}