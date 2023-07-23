using Common.Architecture.Local.Services.Abstract;
using VContainer.Unity;

namespace Common.Architecture.Local.ComposedSceneConfig
{
    public class LocalScopeProvider : ILocalScopeProvider
    {
        public LocalScopeProvider(LifetimeScope scope)
        {
            _scope = scope;
        }
        
        private readonly LifetimeScope _scope;

        public LifetimeScope Scope => _scope;
    }
}