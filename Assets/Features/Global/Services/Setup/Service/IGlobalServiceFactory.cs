using Common.Architecture.DiContainer.Abstract;

namespace Global.Services.Setup.Service
{
    public interface IGlobalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks);
    }
}