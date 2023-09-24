using System.Collections.Generic;
using Menu.Collections.Global;
using Menu.Common.Navigation;
using Menu.Common.Pages;
using UnityEngine;

namespace Menu.Collections.UI
{
    [DisallowMultipleComponent]
    public class CollectionsView : MonoBehaviour, ICollectionsView
    {
        [SerializeField] private EntriesStorage<CollectionEntryView, AvatarHandle> _entries;
        [SerializeField] private PageIndexViewFactory _pageIndexViewFactory;
        [SerializeField] private PagesSwitchInvoker _pagesSwitchInvoker;

        private ITabNavigation _navigation;
        private RectTransform _transform;

        private PagesContainer _pages;
        
        public ITabNavigation Navigation => _navigation;
        public RectTransform Transform => _transform;

        private void Awake()
        {
            _navigation = GetComponent<ITabNavigation>();
            _transform = GetComponent<RectTransform>();
        }
        
        public void Construct(IReadOnlyList<AvatarHandle> avatars)
        {
            var pagesFactory = new PagesFactory<CollectionEntryView, AvatarHandle>(_entries, _pageIndexViewFactory);
            var pages = pagesFactory.Create(avatars);
            _pages = new PagesContainer(pages, _pagesSwitchInvoker);
        }

        public void Open()
        {
            _pages.Enable();
        }
        
        public void Disable()
        {
            _pages.Disable();
        }
    }
}