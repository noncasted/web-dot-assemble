using GamePlay.Level.Dots.Runtime;
using Global.Services.Inputs.View.Runtime.Mouses;
using Global.Services.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Level.Services.DotMovers.Runtime
{
    public class MoveProcessor : IUpdatable
    {
        public MoveProcessor(IDot dot, IUpdater updater, IMouseInput mouseInput, RectTransform root)
        {
            _transform = dot.View.Transform;
            _updater = updater;
            _mouseInput = mouseInput;
            _root = root;
        }

        private readonly RectTransform _transform;
        private readonly IUpdater _updater;
        private readonly IMouseInput _mouseInput;
        private readonly RectTransform _root;

        public void OnUpdate(float delta)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _root,
                _mouseInput.Position,
                null,
                out var localPoint);

            _transform.anchoredPosition = localPoint;
        }

        public void Start()
        {
            _updater.Add(this);
        }

        public void Dispose()
        {
            _updater.Remove(this);
        }
    }
}