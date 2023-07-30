using GamePlay.Level.Fields.Lifetime;
using GamePlay.Level.Fields.Runtime;
using UnityEngine;

namespace GamePlay.Level.Fields.Factory
{
    public class FieldFactory : IFieldFactory
    {
        public FieldFactory(Transform cellsRoot)
        {
            _cellsRoot = cellsRoot;
        }
        private readonly Transform _cellsRoot;

        public IField Create(IFieldScanner scanner, IFieldValidator validator)
        {
            var cells = scanner.Scan(_cellsRoot);
            validator.Validate(cells);
            var lifetime = new FieldLifetime();
            var field = new Field(lifetime, cells);

            return field;
        }
    }
}