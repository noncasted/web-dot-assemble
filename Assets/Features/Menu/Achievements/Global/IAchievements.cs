using System.Collections.Generic;
using Menu.Common.Tasks.Abstract;

namespace Menu.Achievements.Global
{
    public interface IAchievements
    {
        IReadOnlyList<IGoalTask> GetAll();
        IReadOnlyList<IGoalTask> GetProgressed();
        void FetchAll();
        IGoalTask Get(string id);
    }
}