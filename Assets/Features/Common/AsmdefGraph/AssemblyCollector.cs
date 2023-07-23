using System.Collections.Generic;
using UnityEditor.Compilation;

namespace Common.AsmdefGraph
{
    public class AssemblyCollector
    {
        private readonly string[] _filter =
        {
            "Unity",
            "Sirenix",
            "Assembly",
            "VContainer",
            "Common",
            "UniTask"
        };
        
        public IReadOnlyList<AssemblyEntry> Collect()
        {
            var assemblies = CompilationPipeline.GetAssemblies();

            var entries = new Dictionary<string, AssemblyEntry>();
    
            foreach (var assembly in assemblies)
            {
                if (IsAllowed(assembly.name) == false)
                    continue;
                
                var entry = new AssemblyEntry(assembly.name);

                entries.Add(assembly.name, entry);
            }

            foreach (var root in assemblies)
            {
                if (entries.ContainsKey(root.name) == false)
                    continue;
                
                var entry = entries[root.name];
                
                foreach (var referenced in root.assemblyReferences)
                {
                    if (entries.ContainsKey(referenced.name) == false)
                        continue;
                    
                    var dependency = entries[referenced.name];
                    entry.AddDependency(dependency);
                }
            }

            var list = new List<AssemblyEntry>();

            foreach (var (_, value) in entries)
                list.Add(value);

            return list;
        }

        private bool IsAllowed(string name)
        {
            foreach (var filter in _filter)
            {
                if (name.Contains(filter) == true)
                    return false;
            }

            return true;
        }
    }
}