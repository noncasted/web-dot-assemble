using Menu.StateMachine.Definitions;
using Menu.StateMachine.Runtime;
using UnityEngine;

namespace Menu.Main.UI
{
    public class MainController : IMainController, ITab
    {
        public MainController(IMainView view, IStateMachine stateMachine)
        {
            _view = view;
            
            view.Navigation.Construct(stateMachine);
        }

        private readonly IMainView _view;

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