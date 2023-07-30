using System.Collections.Generic;

namespace GamePlay.Level.Dots.Definitions
{
    public interface IDotDefinitionsStorage
    {
        IReadOnlyList<IDotDefinition>  Definitions { get; }

        IDotDefinition GetRandom();
    }
}