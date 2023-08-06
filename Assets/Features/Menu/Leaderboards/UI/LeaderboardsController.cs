using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Leaderboards.UI
{
    public class LeaderboardsController : ILeaderboardsController, ITab
    {
        public LeaderboardsController(ILeaderboardsView view)
        {
            _view = view;
        }

        private readonly ILeaderboardsView _view;

        public RectTransform Transform => _view.Transform;
        
        public void Activate()
        {
            
        }

        public void Deactivate()
        {
            
        }
    }
}