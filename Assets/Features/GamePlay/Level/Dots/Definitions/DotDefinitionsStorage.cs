using System.Collections.Generic;
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
    public class DotDefinitionsStorage : ScriptableObject, IDotDefinitionsStorage
    {
        [SerializeField] private DotDefinition[] _definition;

        public IReadOnlyList<IDotDefinition> Definitions => _definition;

        public IDotDefinition GetRandom()
        {
            var random = Random.Range(0, Definitions.Count);
            return Definitions[random];
        }

        [Button("Scan")]
        private void Scan()
        {
#if UNITY_EDITOR
            var definitions = new List<DotDefinition>();
            var guids = AssetDatabase.FindAssets($"t:{typeof(DotDefinition)}");

            foreach (var guid in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<DotDefinition>(assetPath);

                if (asset == null)
                    continue;

                definitions.Add(asset);
            }

            Undo.RecordObject(this, "Assign definitions");

            _definition = definitions.ToArray();

            Undo.RecordObject(this, "Assign definitions");
#endif
        }
    }
}