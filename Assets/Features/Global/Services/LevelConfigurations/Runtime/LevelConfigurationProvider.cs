using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using GamePlay.Loop.Modes;
using Global.LevelConfigurations.Avatars;
using Global.LevelConfigurations.Definition;
using Global.Publisher.Abstract.DataStorages;

namespace Global.LevelConfigurations.Runtime
{
    public class LevelConfigurationProvider : ILevelConfigurationProvider
    {
        public LevelConfigurationProvider(
            IDataStorage dataStorage,
            IReadOnlyList<ILevelConfiguration> configurations)
        {
            _dataStorage = dataStorage;
            _configurations = configurations;
        }

        private readonly IDataStorage _dataStorage;
        private readonly IReadOnlyList<ILevelConfiguration> _configurations;
        
        private GameMode _mode = GameMode.Quads;
        private IAvatarDefinition _playerAvatar;

        public GameMode Mode => _mode;
        public IAvatarDefinition PlayerAvatar => _playerAvatar;

        public void SetMode(GameMode mode)
        {
            _mode = mode;
        }

        public void SetPlayerAvatar(IAvatarDefinition playerAvatar)
        {
            _playerAvatar = playerAvatar;
        }

        public async UniTask<ILevelConfiguration> GetConfiguration()
        {
            var save = await _dataStorage.GetEntry<LevelsSave>(LevelsSave.Key)!;
            var index = save.PassedIndex;

            if (index >= _configurations.Count)
                return _configurations.Last();

            return _configurations[index];
        }

        public async UniTask NextConfiguration()
        {
            var save = await _dataStorage.GetEntry<LevelsSave>(LevelsSave.Key)!;
            save.OnNext();
        }
    }
}