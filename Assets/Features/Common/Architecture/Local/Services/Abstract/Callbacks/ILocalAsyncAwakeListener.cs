using Common.Architecture.Local.Services.Abstract.EventLoops;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.Local.Services.Abstract.Callbacks
{
    public interface ILocalAsyncAwakeListener : IEventBase
    {
        UniTask OnAwakeAsync();
    }
}