using System.Threading;
using Common.Architecture.Local.Abstract.Callbacks;
using Cysharp.Threading.Tasks;
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
        
        public async UniTask Activate(CancellationToken cancellation)
        {
            _view.Navigation.Enable();
            _view.Open();
        }

        public void Deactivate()
        {
            _view.Navigation.Disable();
            _view.Disable();
        }
    }
}