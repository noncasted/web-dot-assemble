using Menu.StateMachine.Definitions;
using Menu.StateMachine.Runtime;
using UnityEngine;

namespace Menu.Collections.UI
{
    public class CollectionsController : ICollectionsController, ITab
    {
        public CollectionsController(ICollectionsView view)
        {
            _view = view;
        }

        private readonly ICollectionsView _view;

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