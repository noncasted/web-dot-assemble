namespace GamePlay.Level.Dots.Runtime.DragHandlers
{
    public readonly struct DotDraggedEvent
    {
        public DotDraggedEvent(IDot dot)
        {
            Dot = dot;
        }

        public readonly IDot Dot;
    }
}