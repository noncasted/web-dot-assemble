using System;
using GamePlay.Level.Cells.Runtime;
using GamePlay.Level.Dots.Definitions;
using GamePlay.Level.Dots.Runtime;
using GamePlay.Level.Dots.Runtime.LifeFlow;
using GamePlay.Level.Dots.Runtime.Setup;
using GamePlay.Level.Fields.Runtime;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GamePlay.Level.Dots.Factory
{
    public class DotFactory : IDotFactory
    {
        public DotFactory(IField field)
        {
            _field = field;
        }

        private readonly IField _field;

        public IDot Create(IDotDefinition definition, ICell cell, IDotLifeFlowConfig config)
        {
            var dotObject = Object.Instantiate(definition.Prefab, cell.Transform);
            dotObject.transform.localPosition = Vector3.zero;

            if (dotObject.TryGetComponent(out IDotBootstrapLinker linker) == false)
            {
                throw new NullReferenceException(
                    $"No implementation of IDotBootstrapLinker interface found on object: {dotObject.name}");
            }

            var view = linker.View;
            var pointerObserver = linker.PointerObserver;
            var lifeFlow = new DotLifeFlow(view, config);
            var dot = new Dot(view, lifeFlow, pointerObserver, definition);
            linker.Image.sprite = definition.Image;

            dot.Enable();
            cell.SetDot(dot);

            _field.OnCellTaken(cell);

            return dot;
        }
    }
}