using UnityEngine;

namespace GamePlay.Level.Dots.Definitions
{
    public interface IDotDefinition
    {
        Sprite Image { get; }
        Sprite ActiveIcon { get; }
        Sprite InactiveIcon { get; }
        GameObject Prefab { get; }
    }
}