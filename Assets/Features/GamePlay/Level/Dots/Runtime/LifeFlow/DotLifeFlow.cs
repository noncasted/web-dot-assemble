﻿using Cysharp.Threading.Tasks;
using GamePlay.Level.Dots.Runtime.View;

namespace GamePlay.Level.Dots.Runtime.LifeFlow
{
    public class DotLifeFlow : IDotLifeFlow
    {
        public DotLifeFlow(IDotView view, IDotLifeFlowConfig lifeFlowConfig)
        {
            _view = view;
            _lifeFlowConfig = lifeFlowConfig;
        }

        private readonly IDotView _view;
        private readonly IDotLifeFlowConfig _lifeFlowConfig;

        private int _cycle;

        public bool IsActive { get; private set; }

        public void GrowFull()
        {
            _cycle = _lifeFlowConfig.MaxCycle;
            _view.Grow(_lifeFlowConfig.MaxCycle, _lifeFlowConfig.MaxCycle);
            IsActive = true;
        }

        public void GrowMinimal()
        {
            _cycle = 1;
            _view.Grow(1, _lifeFlowConfig.MaxCycle);
        }

        public void OnStep()
        {
            _cycle++;

            if (_cycle == _lifeFlowConfig.MaxCycle)
                IsActive = true;

            _view.Grow(_cycle, _lifeFlowConfig.MaxCycle);
        }

        public async UniTask OnDeath()
        {
            await _view.Destroy();
        }
    }
}