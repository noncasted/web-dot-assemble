using GamePlay.Level.Dots.Common;
using UnityEngine;

namespace GamePlay.Level.Dots.Definitions
{
    [CreateAssetMenu(fileName = DotsRoutes.DefinitionName,
        menuName = DotsRoutes.DefinitionPath)]
    public class DotDefinition : ScriptableObject, IDotDefinition
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Color _color;

        public Color Color => _color;
        public GameObject Prefab => _prefab;
    }
}