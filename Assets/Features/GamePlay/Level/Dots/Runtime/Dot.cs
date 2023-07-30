using System;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Dots.Definitions;
using GamePlay.Level.Dots.Runtime.DragHandlers;
using GamePlay.Level.Dots.Runtime.LifeFlow;
using GamePlay.Level.Dots.Runtime.View;
using GamePlay.Level.Fields.Lifetime;
using Global.Services.System.MessageBrokers.Runtime;
using UnityEngine;

namespace GamePlay.Level.Dots.Runtime
{
    public class Dot : IDot
    {
        public Dot(IDotView view, IDotLifeFlow lifeFlow, IDotPointerObserver pointerObserver, IDotDefinition definition)
        {
            _view = view;
            _lifeFlow = lifeFlow;
            _pointerObserver = pointerObserver;
            _definition = definition;
        }

        private readonly IDotView _view;
        private readonly IDotLifeFlow _lifeFlow;
        private readonly IDotPointerObserver _pointerObserver;
        private readonly IDotDefinition _definition;

        private IDisposable _fieldStepListener;

        public IDotDefinition Definition => _definition;
        public IDotView View => _view;

        public void InitAsStartup()
        {
            _lifeFlow.GrowFull();
        }

        public void InitAsInGame()
        {
            _lifeFlow.GrowFull();
        }

        public void Enable()
        {
            Debug.Log("Enable");
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
            _lifeFlow.OnStep();
        }

        public async UniTask Destroy()
        {
            await _lifeFlow.OnDeath();
        }

        private void OnDropped()
        {

        }

        private void OnDragged()
        {
            Debug.Log($"On dragged: {_lifeFlow.IsActive}");
            if (_lifeFlow.IsActive == false)
                return;

            Msg.Publish(new DotDraggedEvent(this));
        }
    }
}