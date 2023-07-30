using GamePlay.Level.Cells.Runtime;
using UnityEngine;

namespace GamePlay.Level.Fields.Factory
{
    public class FieldScanner : IFieldScanner
    {
        public ICell[] Scan(Transform root)
        {
            var childCount = root.childCount;
            var fieldCells = root.GetComponentsInChildren<ICell>();

            return fieldCells;
        }
    }
}