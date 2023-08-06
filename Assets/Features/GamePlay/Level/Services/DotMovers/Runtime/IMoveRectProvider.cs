using UnityEngine;

namespace GamePlay.Level.Services.DotMovers.Runtime
{
    public interface IMoveRectProvider
    {
        Transform MoveRect { get; }
    }
}