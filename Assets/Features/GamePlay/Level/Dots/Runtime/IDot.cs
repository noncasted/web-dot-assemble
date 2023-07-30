using Cysharp.Threading.Tasks;
using GamePlay.Level.Dots.Definitions;
using GamePlay.Level.Dots.Runtime.View;

namespace GamePlay.Level.Dots.Runtime
{
    public interface IDot
    {
        IDotDefinition Definition { get; }
        IDotView View { get; }

        void InitAsStartup();
        void InitAsInGame();

        void Enable();
        void Disable();
        UniTask Destroy();
    }
}