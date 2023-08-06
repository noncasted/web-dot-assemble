using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.Level.Dots.Runtime.View
{
    public interface IDotView
    {
        Transform Transform { get; }
        void Grow(int currentCycle, int maxCycle);
        UniTask Destroy();
    }
}