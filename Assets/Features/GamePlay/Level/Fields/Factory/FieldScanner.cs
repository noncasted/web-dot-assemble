using GamePlay.Level.Cells.Runtime;
using UnityEngine;

namespace GamePlay.Level.Fields.Factory
{
    public class FieldScanner : IFieldScanner
    {
        public ICell[][] Scan(Transform root)
        {
            var childCount = root.childCount;
            var fieldCells = new ICell[childCount][];

            for (var i = 0; i < root.childCount; i++)
            {
                var child = root.GetChild(i);
                var childCells = child.GetComponentsInChildren<ICell>();
                fieldCells[i] = childCells;
            }

            return fieldCells;
        }
    }
}