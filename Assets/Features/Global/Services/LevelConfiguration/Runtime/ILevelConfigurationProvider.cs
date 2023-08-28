using Global.LevelConfiguration.Definition;

namespace Global.LevelConfiguration.Runtime
{
    public interface ILevelConfigurationProvider
    {
        ILevelSetupConfiguration Configuration { get; }
        
        void SetConfiguration(ILevelSetupConfiguration configuration);
    }
}