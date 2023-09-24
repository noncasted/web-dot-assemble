using System.Linq;
using GamePlay.Level.Cells.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.Fields.Runtime
{
    [DisallowMultipleComponent]
    public class FieldAligner : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float _space;
        [SerializeField] private Vector2Int _size;

        [SerializeField] private Transform[] _cells;

        [Button]
        private void Align()
        {
            for (var y = 0; y < _size.y; y++)
            {
                for (var x = 0; x < _size.x; x++)
                {
                    var position = new Vector2(x, y);
                    position *= _space;
                    _cells[y * _size.x + x].localPosition = position;
                }
            }
        }

        [Button]
        private void Scan()
        {
            var cells = FindObjectsByType<Cell>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            _cells = cells
                .OrderBy(cell => cell.transform.GetSiblingIndex())
                .Select(cell => cell.transform)
                .ToArray();
        }
    }
}