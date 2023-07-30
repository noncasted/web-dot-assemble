using UnityEngine;

namespace GamePlay.Level.Services.DotMovers.Runtime
{
    public class MoveRectProvider : IMoveRectProvider
    {
        public MoveRectProvider(RectTransform moveRect)
        {
            _moveRect = moveRect;
        }

        private readonly RectTransform _moveRect;

        public RectTransform MoveRect => _moveRect;
    }
}