using System.Collections.Generic;

namespace Common.AsmdefGraph
{
    public class AssemblyEntry
    {
        public AssemblyEntry(string name)
        {
            Name = name;
            _dependencies = new List<AssemblyEntry>();
        }

        private readonly List<AssemblyEntry> _dependencies;

        public readonly string Name;
        public IReadOnlyList<AssemblyEntry> Dependencies => _dependencies;

        public void AddDependency(AssemblyEntry dependency)
        {
            _dependencies.Add(dependency);
        }
    }
}