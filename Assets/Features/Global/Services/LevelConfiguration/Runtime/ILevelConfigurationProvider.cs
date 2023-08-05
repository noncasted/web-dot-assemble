using Global.Services.LevelConfiguration.Definition;

namespace Global.Services.LevelConfiguration.Runtime
{
    public interface ILevelConfigurationProvider
    {
        ILevelSetupConfiguration Configuration { get; }
        
        void SetConfiguration(ILevelSetupConfiguration configuration);
    }
}