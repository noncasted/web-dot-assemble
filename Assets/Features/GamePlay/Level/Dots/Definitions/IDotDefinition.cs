using UnityEngine;

namespace GamePlay.Level.Dots.Definitions
{
    public interface IDotDefinition
    {
        Color Color { get; }
        GameObject Prefab { get; }
    }
}