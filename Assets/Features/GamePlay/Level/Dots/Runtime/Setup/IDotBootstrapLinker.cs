using GamePlay.Level.Dots.Runtime.DragHandlers;
using GamePlay.Level.Dots.Runtime.View;
using UnityEngine;

namespace GamePlay.Level.Dots.Runtime.Setup
{
    public interface IDotBootstrapLinker
    {
        SpriteRenderer Image { get; }
        IDotView View { get; }
        IDotPointerObserver PointerObserver { get; }
    }
}