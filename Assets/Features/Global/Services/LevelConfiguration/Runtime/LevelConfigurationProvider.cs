using Global.Services.LevelConfiguration.Definition;

namespace Global.Services.LevelConfiguration.Runtime
{
    public class LevelConfigurationProvider : ILevelConfigurationProvider
    {
        public ILevelSetupConfiguration Configuration { get; private set; }

        public void SetConfiguration(ILevelSetupConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}