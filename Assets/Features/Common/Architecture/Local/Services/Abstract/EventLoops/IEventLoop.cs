using Cysharp.Threading.Tasks;

namespace Common.Architecture.Local.Services.Abstract.EventLoops
{
    public interface IEventLoop
    {
        void Clear();
        void Listen(object service);
        UniTask Run();
    }
}