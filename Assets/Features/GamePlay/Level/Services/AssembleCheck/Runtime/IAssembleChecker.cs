using Cysharp.Threading.Tasks;

namespace GamePlay.Level.Services.AssembleCheck.Runtime
{
    public interface IAssembleChecker
    {
        UniTask<CheckResult> CheckAssemble();
    }
}