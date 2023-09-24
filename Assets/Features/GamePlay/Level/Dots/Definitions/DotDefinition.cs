using GamePlay.Level.Dots.Common;
using UnityEngine;

namespace GamePlay.Level.Dots.Definitions
{
    [CreateAssetMenu(fileName = DotsRoutes.DefinitionName,
        menuName = DotsRoutes.DefinitionPath)]
    public class DotDefinition : ScriptableObject, IDotDefinition
    {
        [SerializeField] private GameObject _prefab;
        
        [SerializeField] private Sprite _largeActive;
        [SerializeField] private Sprite _largeInactive;
        [SerializeField] private Sprite _small;

        public Sprite Image => _largeActive;
        public Sprite ActiveIcon => _small;
        public Sprite InactiveIcon => _largeInactive;
        public GameObject Prefab => _prefab;
 
        public void SetImages(Sprite largeActive, Sprite largeInactive, Sprite small)
        {
            _largeActive = largeActive;
            _largeInactive = largeInactive;
            _small = small;
        }
    }
}