using Features.Global.Services.LevelConfiguration.Definition;

namespace Features.Global.Services.LevelConfiguration.Runtime
{
    public interface ILevelConfigurationProvider
    {
        ILevelSetupConfiguration Configuration { get; }
        
        void SetConfiguration(ILevelSetupConfiguration configuration);
    }
}