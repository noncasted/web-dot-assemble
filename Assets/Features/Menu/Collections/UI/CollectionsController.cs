using Common.Architecture.Local.Services.Abstract.Callbacks;
using Menu.Collections.Global;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Collections.UI
{
    public class CollectionsController : ICollectionsController, ITab, ILocalAwakeListener
    {
        public CollectionsController(ICollectionsView view, ICollections collection)
        {
            _view = view;
            _collection = collection;
        }

        private readonly ICollectionsView _view;
        private readonly ICollections _collection;

        public RectTransform Transform => _view.Transform;
        
        public void OnAwake()
        {
            _view.Construct(_collection.All);
        }
        
        public void Activate()
        {
            _view.Navigation.Enable();
            _view.Enable();
            _view.Open();
        }

        public void Deactivate()
        {
            _view.Navigation.Disable();
            _view.Disable();
        }
    }
}