using Common.Architecture.DiContainer.Abstract;

namespace Global.Setup.Service
{
    public interface IGlobalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks);
    }
}