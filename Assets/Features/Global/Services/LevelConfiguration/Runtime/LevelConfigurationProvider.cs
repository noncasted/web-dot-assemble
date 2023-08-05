using Global.Services.LevelConfiguration.Definition;

namespace Global.Services.LevelConfiguration.Runtime
{
    public class LevelConfigurationProvider : ILevelConfigurationProvider
    {
        private ILevelSetupConfiguration _configuration;

        public ILevelSetupConfiguration Configuration => _configuration;

        public void SetConfiguration(ILevelSetupConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}