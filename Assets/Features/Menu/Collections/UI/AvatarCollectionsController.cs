using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Collections.UI
{
    public class AvatarCollectionsController : IAvatarCollectionsController, ITab
    {
        public AvatarCollectionsController(IAvatarCollectionsView view)
        {
            _view = view;
        }

        private readonly IAvatarCollectionsView _view;

        public RectTransform Transform => _view.Transform;
        
        public void Activate()
        {
            
        }

        public void Deactivate()
        {
            
        }
    }
}