using Cysharp.Threading.Tasks;

namespace GamePlay.Level.Dots.Runtime.LifeFlow
{
    public interface IDotLifeFlow
    {
        bool IsActive { get; }

        void GrowFull();
        void GrowMinimal();
        void OnStep();
        UniTask OnDeath();
    }
}