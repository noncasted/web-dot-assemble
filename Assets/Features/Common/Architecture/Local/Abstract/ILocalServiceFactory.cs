using Common.Architecture.DiContainer.Abstract;

namespace Common.Architecture.Local.Abstract
{
    public interface ILocalServiceFactory
    {
        public void Create(IServiceCollection builder, ILocalUtils utils);
    }
}