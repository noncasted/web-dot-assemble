using System.Collections.Generic;
using Global.Options.Common;
using UnityEngine;

namespace Global.Options.Runtime
{
    [CreateAssetMenu(fileName = "Options", menuName = OptionRoutes.RootPath)]
    public class Options : ScriptableObject, IOptions
    {
        [SerializeField] private List<EnvironmentType> _optionsPriority;
        [SerializeField] private OptionsRegistriesDictionary _registries;

        public void Setup()
        {
            foreach (var (_, registry) in _registries)
                registry.CacheRegistry();
        }

        public T GetOptions<T>() where T : OptionsEntry
        {
            foreach (var environmentType in _optionsPriority)
            {
                var currentEnvironment = _registries[environmentType];

                if (currentEnvironment.TryGetEntry<T>(out var environmentEntry) == true)
                    return environmentEntry;
            }
            
            return null;
        }
    }
}