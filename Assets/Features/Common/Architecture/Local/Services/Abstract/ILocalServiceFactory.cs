using Common.Architecture.DiContainer.Abstract;

namespace Common.Architecture.Local.Services.Abstract
{
    public interface ILocalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry);
    }
}