using GamePlay.Level.Cells.Runtime;
using UnityEngine;

namespace GamePlay.Level.Fields.Factory
{
    public interface IFieldScanner
    {
        ICell[][] Scan(Transform root);
    }
}