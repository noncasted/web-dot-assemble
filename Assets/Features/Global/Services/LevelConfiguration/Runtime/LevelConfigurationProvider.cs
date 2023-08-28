using Global.LevelConfiguration.Definition;

namespace Global.LevelConfiguration.Runtime
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