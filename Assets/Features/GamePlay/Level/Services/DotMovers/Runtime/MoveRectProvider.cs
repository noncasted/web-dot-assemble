using UnityEngine;

namespace GamePlay.Level.Services.DotMovers.Runtime
{
    public class MoveRectProvider : IMoveRectProvider
    {
        public MoveRectProvider(Transform moveRect)
        {
            _moveRect = moveRect;
        }

        private readonly Transform _moveRect;

        public Transform MoveRect => _moveRect;
    }
}