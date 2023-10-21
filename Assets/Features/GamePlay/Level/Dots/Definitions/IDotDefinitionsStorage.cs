using System.Collections.Generic;

namespace GamePlay.Level.Dots.Definitions
{
    public interface IDotDefinitionsStorage
    {
        IReadOnlyList<IDotDefinition>  Definitions { get; }
        IReadOnlyDictionary<int, IDotDefinition> Dictionary { get; }

        void Setup();
        IDotDefinition GetRandom();
    }
}