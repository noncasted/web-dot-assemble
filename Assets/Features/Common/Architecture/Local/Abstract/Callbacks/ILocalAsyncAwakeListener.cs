using Common.Architecture.Local.Abstract.EventLoops;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.Local.Abstract.Callbacks
{
    public interface ILocalAsyncAwakeListener : IEventBase
    {
        UniTask OnAwakeAsync();
    }
}