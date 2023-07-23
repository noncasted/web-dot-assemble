using VContainer.Unity;

namespace Common.Architecture.Local.Services.Abstract
{
    public interface ILocalScopeProvider
    {
        LifetimeScope Scope { get; }   
    }
}