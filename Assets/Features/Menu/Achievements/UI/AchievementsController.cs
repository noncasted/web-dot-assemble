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
            _view.Navigation.Enable();
        }

        public void Deactivate()
        {
            _view.Navigation.Disable();
        }
    }
}