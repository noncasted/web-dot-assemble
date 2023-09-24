using System.Collections.Generic;
using Common.Serialization.ScriptableRegistries;
using GamePlay.Level.Dots.Common;
using UnityEngine;
using Sirenix.OdinInspector;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GamePlay.Level.Dots.Definitions
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DotsRoutes.StorageName,
        menuName = DotsRoutes.StoragePath)]
    public class DotDefinitionsStorage : ScriptableRegistry<DotDefinition>, IDotDefinitionsStorage
    {
        [SerializeField] private Sprite[] _images;
        
        public IReadOnlyList<IDotDefinition> Definitions => Objects;

        public IDotDefinition GetRandom()
        {
            var random = Random.Range(0, Definitions.Count);
            return Definitions[random];
        }

        [Button]
        private void AssignImages()
        {
            #if UNITY_EDITOR
            for (var i = 0; i < Objects.Count; i++)
            {
                var target = Objects[i];
                Undo.RecordObject(target, "Assign images");
                var index = i * 3;
                target.SetImages(_images[index + 1], _images[index], _images[index + 2]);
                Undo.RecordObject(target, "Assign images");
            }   
            #endif
        }
    }
}