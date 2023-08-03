using Cysharp.Threading.Tasks;
using GamePlay.Level.Dots.Runtime;

namespace GamePlay.Level.Dots.Destroyer
{
    public interface IDotDestroyer
    {
        UniTask Destroy(IDot dot);
    }
}