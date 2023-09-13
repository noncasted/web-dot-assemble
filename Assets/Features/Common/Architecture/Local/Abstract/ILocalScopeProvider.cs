using VContainer.Unity;

namespace Common.Architecture.Local.Abstract
{
    public interface ILocalScopeProvider
    {
        LifetimeScope Scope { get; }   
    }
}