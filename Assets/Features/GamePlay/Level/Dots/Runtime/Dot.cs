using System;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Dots.Definitions;
using GamePlay.Level.Dots.Runtime.DragHandlers;
using GamePlay.Level.Dots.Runtime.LifeFlow;
using GamePlay.Level.Dots.Runtime.View;
using GamePlay.Level.Fields.Lifetime;
using Global.Services.System.MessageBrokers.Runtime;

namespace GamePlay.Level.Dots.Runtime
{
    public class Dot : IDot
    {
        public Dot(IDotView view, IDotLifeFlow lifeFlow, IDotPointerObserver pointerObserver, IDotDefinition definition)
        {
            _view = view;
            LifeFlow = lifeFlow;
            _pointerObserver = pointerObserver;
            _definition = definition;
        }

        private readonly IDotView _view;
        private readonly IDotPointerObserver _pointerObserver;
        private readonly IDotDefinition _definition;

        private IDisposable _fieldStepListener;

        public IDotDefinition Definition => _definition;
        public IDotView View => _view;
        public IDotLifeFlow LifeFlow { get; }

        public void InitAsStartup()
        {
            LifeFlow.GrowFull();
        }

        public void InitAsInGame()
        {
            LifeFlow.GrowMinimal();
        }

        public void Enable()
        {
            _fieldStepListener = Msg.Listen<FieldStepEvent>(OnFieldStep);
            _pointerObserver.Dragged += OnDragged;
            _pointerObserver.Dropped += OnDropped;
        }

        public void Disable()
        {
            _fieldStepListener.Dispose();
            _pointerObserver.Dragged -= OnDragged;
            _pointerObserver.Dropped -= OnDropped;
        }

        private void OnFieldStep(FieldStepEvent payload)
        {
            LifeFlow.OnStep();
        }

        public async UniTask Destroy()
        {
            await LifeFlow.OnDeath();
        }

        private void OnDropped()
        {

        }

        private void OnDragged()
        {
            if (LifeFlow.IsActive == false)
                return;

            Msg.Publish(new DotDraggedEvent(this));
        }
    }
}