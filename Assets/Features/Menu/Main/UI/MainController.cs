using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Main.UI
{
    public class MainController : IMainController, ITab
    {
        public MainController(IMainView view)
        {
            _view = view;
        }

        private readonly IMainView _view;

        public RectTransform Transform => _view.Transform;
        
        public void Activate()
        {
            
        }

        public void Deactivate()
        {
            
        }
    }
}