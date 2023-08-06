using Cysharp.Threading.Tasks;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Runtime;
using UnityEngine;

namespace Menu.Collections.UI
{
    public class CollectionsController : ICollectionsController, ITab
    {
        public CollectionsController(ICollectionsView view, IStateMachine stateMachine)
        {
            _view = view;
            _stateMachine = stateMachine;
            
            _view.Navigation.Construct(stateMachine);
        }

        private readonly ICollectionsView _view;
        private readonly IStateMachine _stateMachine;

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