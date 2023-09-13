using Cysharp.Threading.Tasks;

namespace Common.Architecture.Local.Abstract.EventLoops
{
    public interface IEventLoop
    {
        void Clear();
        void Listen(object service);
        UniTask Run();
    }
}