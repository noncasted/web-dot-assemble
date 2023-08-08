using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Global.Services.Publisher.Abstract.DataStorages;
using Global.Services.Setup.Service.Callbacks;
using Menu.Achievements.Definitions;

namespace Menu.Achievements.Global
{
    public class Achievements : IAchievements, IGlobalAsyncBootstrapListener
    {
        public Achievements(IDataStorage storage, IAchievementFactory factory, IAchievementsConfig config)
        {
            _storage = storage;
            _factory = factory;
            _config = config;
        }
        
        private readonly IDataStorage _storage;
        private readonly IAchievementFactory _factory;
        private readonly IAchievementsConfig _config;

        private readonly Dictionary<AchievementType, IAchievement> _achievements = new();

        public async UniTask OnBootstrapAsync()
        {
            var saves = _storage.GetEntry<AchievementsSave>("achievements");
            var configs = _config.GetConfigs();

            foreach (var config in configs)
            {
                var achievement = _factory.Create(config, saves.Entries);
                _achievements[config.Type] = achievement;
            }
        }

        public IReadOnlyList<IAchievement> GetAll()
        {
            return _achievements.Values.ToList();
        }

        public IReadOnlyList<IAchievement> GetProgressed()
        {
            var progressed = new List<IAchievement>();
            
            foreach (var (_, value) in _achievements)
            {
                var progress = value.Progress;
                
                if (progress.Progress <= progress.PreviousFetch)
                    continue;

                progressed.Add(value);
            }

            return progressed;
        }

        public void FetchAll()
        {
            foreach (var (_, value) in _achievements)
                value.Progress.Fetch();
        }
    }
}