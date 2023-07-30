using GamePlay.Level.Dots.Runtime.DragHandlers;
using GamePlay.Level.Dots.Runtime.View;
using UnityEngine;

namespace GamePlay.Level.Dots.Runtime.Setup
{
    [DisallowMultipleComponent]
    public class DotBootstrapLinker : MonoBehaviour, IDotBootstrapLinker
    {
        [SerializeField] private DotView _view;
        [SerializeField] private DotPointerObserver _pointerObserver;

        public IDotView View => _view;
        public IDotPointerObserver PointerObserver => _pointerObserver;
    }
}