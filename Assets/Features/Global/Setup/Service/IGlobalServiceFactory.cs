using Common.Architecture.DiContainer.Abstract;

namespace Global.Setup.Service
{
    public interface IGlobalServiceFactory
    {
        public void Create(IDependencyRegister builder, IGlobalUtils utils);
    }
}