using System.Collections.Generic;
using System.Linq;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.DataStorages;
using Menu.Common.Tasks.Abstract;

namespace Menu.Achievements.Global
{
    public class Achievements : IAchievements, IScopeEnableAsyncListener
    {
        public Achievements(
            IDataStorage storage,
            IReadOnlyList<ITaskFactory> taskFactories)
        {
            _storage = storage;
            _taskFactories = taskFactories;
        }

        private readonly IDataStorage _storage;
        private readonly IReadOnlyList<ITaskFactory> _taskFactories;

        private readonly Dictionary<string, IGoalTask> _achievements = new();

        public async UniTask OnEnabledAsync()
        {
            var saves = await _storage.GetEntry<AchievementsSave>(AchievementsSave.Key);

            foreach (var factory in _taskFactories)
            {
                saves.Entries.TryGetValue(factory.Key, out var progress);
                var task = factory.Create(progress);
                _achievements.Add(factory.Key, task);
            }
        }

        public IReadOnlyList<IGoalTask> GetAll()
        {
            return _achievements.Values.ToList();
        }

        public IReadOnlyList<IGoalTask> GetProgressed()
        {
            var progressed = new List<IGoalTask>();

            foreach (var (_, value) in _achievements)
            {
                var progress = value.Progress;

                if (progress.Current <= progress.Previous)
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

        public IGoalTask Get(string id) 
        {
            return _achievements[id];
        }
    }
}