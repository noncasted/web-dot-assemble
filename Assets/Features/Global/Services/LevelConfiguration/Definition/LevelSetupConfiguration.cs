using Global.LevelConfiguration.Avatars;

namespace Global.LevelConfiguration.Definition
{
    public class LevelSetupConfiguration : ILevelSetupConfiguration
    {
        public LevelSetupConfiguration(
            IAvatarDefinition playerAvatar,
            IAvatarDefinition enemyAvatar,
            ILevelConfiguration configuration)
        {
            _playerAvatar = playerAvatar;
            _enemyAvatar = enemyAvatar;
            _configuration = configuration;
        }
        
        private readonly IAvatarDefinition _playerAvatar;
        private readonly IAvatarDefinition _enemyAvatar;
        private readonly ILevelConfiguration _configuration;

        public IAvatarDefinition PlayerAvatar => _playerAvatar;
        public IAvatarDefinition EnemyAvatar => _enemyAvatar;
        public ILevelConfiguration LevelData => _configuration;
    }
}