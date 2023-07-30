using System;
using GamePlay.Level.Cells.Runtime;

namespace GamePlay.Level.Fields.Factory
{
    public class FieldValidator : IFieldValidator
    {
        public void Validate(ICell[][] cells)
        {
            foreach (var row in cells)
            {
                foreach (var cell in row)
                {
                    if (cell == null)
                        throw new NullReferenceException("Missing cell in a field");
                }
            }
        }
    }
}