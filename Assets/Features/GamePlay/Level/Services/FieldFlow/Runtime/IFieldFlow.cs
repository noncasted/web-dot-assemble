using System.Threading;
using Cysharp.Threading.Tasks;

namespace GamePlay.Level.Services.FieldFlow.Runtime
{
    public interface IFieldFlow
    {
        UniTask Setup(CancellationToken cancellationToken);
        UniTask Run(CancellationToken cancellation);
    }
}