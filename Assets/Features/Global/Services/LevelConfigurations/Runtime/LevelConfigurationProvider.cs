using System.Collections.Generic;
using System.Linq;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Dots.Definitions;
using GamePlay.Loop.Modes;
using Global.LevelConfigurations.Avatars;
using Global.LevelConfigurations.Definition;
using Global.Publisher.Abstract.DataStorages;

namespace Global.LevelConfigurations.Runtime
{
    public class LevelConfigurationProvider : ILevelConfigurationProvider, IScopeLoadAsyncListener
    {
        public LevelConfigurationProvider(
            IDotDefinitionsStorage dots,
            IDataStorage dataStorage,
            IReadOnlyList<ILevelConfiguration> configurations,
            IAvatarsRegistry avatars)
        {
            _dots = dots;
            _dataStorage = dataStorage;
            _configurations = configurations;
            _avatars = avatars;
        }

        private readonly IDotDefinitionsStorage _dots;
        private readonly IDataStorage _dataStorage;
        private readonly IReadOnlyList<ILevelConfiguration> _configurations;
        private readonly IAvatarsRegistry _avatars;

        private IReadOnlyList<IDotDefinition> _selectedDots;
        private GameMode _mode = GameMode.Quads;
        private IAvatarDefinition _playerAvatar;
        private LevelsSave _save;

        public GameMode Mode => _mode;
        public IAvatarDefinition PlayerAvatar => _playerAvatar;

        public async UniTask OnLoadedAsync()
        {
            _dots.Setup();
            _avatars.Setup();

            _save = await _dataStorage.GetEntry<LevelsSave>(LevelsSave.Key);

            IAvatarDefinition avatar;

            if (string.IsNullOrEmpty(_save.SelectedAvatar) == false)
                avatar = _avatars.Dictionary[_save.SelectedAvatar];
            else
                avatar = _avatars.GetDefault();
            
            SetPlayerAvatar(avatar);
        }

        public void SetMode(GameMode mode)
        {
            _mode = mode;
        }

        public void SetPlayerAvatar(IAvatarDefinition playerAvatar)
        {
            _playerAvatar = playerAvatar;
        }

        public IReadOnlyList<IDotDefinition> GetSelectedDots()
        {
            return _selectedDots;
        }

        public void UpdateSelectedDots(IReadOnlyList<IDotDefinition> dots)
        {
            _selectedDots = dots;
            _save.UpdateSelectedDots(dots);
        }

        public async UniTask<ILevelConfiguration> GetConfiguration()
        {
            var index = _save.PassedIndex;

            if (index >= _configurations.Count)
                return _configurations.Last();

            return _configurations[index];
        }

        public async UniTask NextConfiguration()
        {
            _save.OnNext();
        }
    }
}