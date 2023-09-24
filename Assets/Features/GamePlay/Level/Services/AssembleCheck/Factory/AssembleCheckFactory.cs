using System;
using GamePlay.Level.Dots.Destroyer;
using GamePlay.Level.Fields.Runtime;
using GamePlay.Level.Services.AssembleCheck.Runtime;
using GamePlay.Loop.Modes;

namespace GamePlay.Level.Services.AssembleCheck.Factory
{
    public class AssembleCheckFactory : IAssembleCheckFactory
    {
        public AssembleCheckFactory(IField field, IDotDestroyer dotDestroyer)
        {
            _field = field;
            _dotDestroyer = dotDestroyer;
        }

        private readonly IField _field;
        private readonly IDotDestroyer _dotDestroyer;

        public IAssembleChecker Create(GameMode gameMode)
        {
            return gameMode switch
            {
                GameMode.Forward => new LineAssembleChecker(_field, _dotDestroyer),
                GameMode.Diagonal => new DiagonalAssembleChecker(_field, _dotDestroyer),
                GameMode.Quads => new QuadAssembleChecker(_field, _dotDestroyer),
                _ => throw new ArgumentOutOfRangeException(nameof(gameMode), gameMode, null)
            };
        }
    }
}