using GamePlay.Level.Services.AssembleCheck.Runtime;
using GamePlay.Loop.Modes;

namespace GamePlay.Level.Services.AssembleCheck.Factory
{
    public interface IAssembleCheckFactory
    {
        IAssembleChecker Create(GameMode gameMode);
    }
}