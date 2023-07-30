using GamePlay.Level.Fields.Runtime;

namespace GamePlay.Level.Fields.Factory
{
    public interface IFieldFactory
    {
        IField Create(IFieldScanner scanner, IFieldValidator validator);
    }
}