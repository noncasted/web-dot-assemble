using Common.Architecture.DiContainer.Abstract;

namespace Common.Architecture.Local.Abstract
{
    public interface ILocalServiceFactory
    {
        public void Create(IDependencyRegister builder, ILocalUtils utils);
    }
}