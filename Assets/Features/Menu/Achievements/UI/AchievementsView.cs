using System.Collections.Generic;
using System.Threading;
using Common.UI.Buttons;
using Cysharp.Threading.Tasks;
using Menu.Achievements.Definitions;
using Menu.Common.Navigation;
using Menu.Common.Pages;
using UnityEngine;

namespace Menu.Achievements.UI
{
    [DisallowMultipleComponent]
    public class AchievementsView : MonoBehaviour, IAchievementsView
    {
        [SerializeField] private EntriesStorage<AchievementEntryView, IAchievement> _entries;
        [SerializeField] private PageIndexViewFactory _pageIndexViewFactory;
        [SerializeField] private PagesSwitchInvoker _pagesSwitchInvoker;
        [SerializeField] private PagesSwitchConfiguration _configuration;
        
        [SerializeField] private ExtendedButton _closeButton;
        [SerializeField] private AchievementDataWindow _dataWindow;

        private ITabNavigation _navigation;
        private RectTransform _transform;
        private PagesContainer _pages;

        private CancellationTokenSource _pagesCancellation;
        private CancellationTokenSource _dataWindowCancellation;

        public ITabNavigation Navigation => _navigation;
        public RectTransform Transform => _transform;

        private void Awake()
        {
            _navigation = GetComponent<ITabNavigation>();
            _transform = GetComponent<RectTransform>();
        }

        public void Enable()
        {
            foreach (var entry in _entries.Entries)
                entry.Selected += OnAchievementSelected;

            _closeButton.Clicked += OnAchievementDeselected;
        }

        public void Disable()
        {
            foreach (var entry in _entries.Entries)
                entry.Selected -= OnAchievementSelected;
            
            _closeButton.Clicked -= OnAchievementDeselected;
            
            _pages.Disable();
        }

        public void Construct(IReadOnlyList<IAchievement> achievements)
        {
            var pagesFactory = new PagesFactory<AchievementEntryView, IAchievement>(_entries, _pageIndexViewFactory, _configuration);
            var pages = pagesFactory.Create(achievements);
            _pages = new PagesContainer(pages, _pagesSwitchInvoker);
        }

        public async UniTask Open()
        {
            _pages.Enable();
        }

        private void OnAchievementSelected(IAchievement achievement)
        {
            _dataWindowCancellation = new CancellationTokenSource();
            _dataWindow.Show(achievement, _dataWindowCancellation.Token).Forget();
        }

        private void OnAchievementDeselected()
        {
            _dataWindowCancellation = new CancellationTokenSource();
            _dataWindow.Hide(_dataWindowCancellation.Token).Forget();
        }
    }
}