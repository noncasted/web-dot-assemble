using System;

namespace GamePlay.Level.Dots.Runtime.DragHandlers
{
    public interface IDotPointerObserver
    {
        event Action Dragged;
        event Action Dropped;
    }
}