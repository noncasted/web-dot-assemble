using Common.Architecture.Local.Services.Abstract.Callbacks;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Achievements.UI
{
    public class AchievementsController : IAchievementsController, ITab
    {
        public AchievementsController(IAchievementsView view)
        {
            _view = view;
        }

        private readonly IAchievementsView _view;

        public RectTransform Transform => _view.Transform;
        
        public void Activate()
        {
            
        }

        public void Deactivate()
        {
            
        }
    }
}