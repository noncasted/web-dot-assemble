using UnityEngine;

namespace GamePlay.Level.Services.DotMovers.Runtime
{
    public interface IMoveRectProvider
    {
        RectTransform MoveRect { get; }
    }
}