using Cysharp.Threading.Tasks;
using GamePlay.Level.Dots.Destroyer;
using GamePlay.Level.Fields.Runtime;

namespace GamePlay.Level.Services.AssembleCheck.Runtime
{
    public class DiagonalAssembleChecker : IAssembleChecker
    {
        public DiagonalAssembleChecker(IField field, IDotDestroyer dotDestroyer)
        {
            _field = field;
        }

        private readonly IField _field;

        public async UniTask<CheckResult> CheckAssemble()
        {
            return new CheckResult();
        }
    }
}