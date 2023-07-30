using GamePlay.Level.Dots.Runtime.DragHandlers;
using GamePlay.Level.Dots.Runtime.View;

namespace GamePlay.Level.Dots.Runtime.Setup
{
    public interface IDotBootstrapLinker
    {
        IDotView View { get; }
        IDotPointerObserver PointerObserver { get; }
    }
}