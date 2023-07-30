using GamePlay.Level.Cells.Runtime;
using GamePlay.Level.Dots.Definitions;
using GamePlay.Level.Dots.Runtime;
using GamePlay.Level.Dots.Runtime.LifeFlow;

namespace GamePlay.Level.Dots.Factory
{
    public interface IDotFactory
    {
        IDot Create(IDotDefinition definition, ICell cell, IDotLifeFlowConfig config, bool isStartup);
    }
}