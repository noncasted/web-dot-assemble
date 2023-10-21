using System.Collections.Generic;
using Common.Serialization.ScriptableRegistries;
using GamePlay.Level.Dots.Common;
using Sirenix.OdinInspector;
using UnityEngine;
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

        private IReadOnlyDictionary<int, IDotDefinition> _dictionary;
        
        public IReadOnlyList<IDotDefinition> Definitions => Objects;
        public IReadOnlyDictionary<int, IDotDefinition> Dictionary => _dictionary;

        public void Setup()
        {
            var dictionary = new Dictionary<int, IDotDefinition>();

            foreach (var dot in Objects)
                dictionary.Add(dot.Id, dot);

            _dictionary = dictionary;
        }

        public IDotDefinition GetRandom()
        {
            var random = Random.Range(0, Definitions.Count);
            return Definitions[random];
        }

        [Button]
        private void Process()
        {
            #if UNITY_EDITOR
            for (var i = 0; i < Objects.Count; i++)
            {
                var target = Objects[i];
                Undo.RecordObject(target, "Assign images");
                var index = i * 3;
                target.SetImages(_images[index + 1], _images[index], _images[index + 2], i);
                Undo.RecordObject(target, "Assign images");
            }   
            #endif
        }
    }
}