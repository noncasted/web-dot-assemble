using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Quests.UI
{
    public class QuestsController : IQuestsController, ITab
    {
        public QuestsController(IQuestsView view)
        {
            _view = view;
        }

        private readonly IQuestsView _view;

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