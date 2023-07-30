using GamePlay.Level.Cells.Runtime;

namespace GamePlay.Level.Fields.Factory
{
    public interface IFieldValidator
    {
        void Validate(ICell[][] cells);
    }
}