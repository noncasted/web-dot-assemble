using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Menu.Achievements.Definitions;
using Menu.Common.Navigation;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Achievements.UI
{
    [DisallowMultipleComponent]
    public class AchievementsView : MonoBehaviour, IAchievementsView
    {
        [SerializeField] private AchievementDataWindow _dataWindow;
        [SerializeField] private AchievementPagePointView _pagePointPrefab;
        [SerializeField] private Transform _pagePointsRoot;

        [SerializeField] private AchievementEntryView[] _entries;

        [SerializeField] private Button _leftPageButton;
        [SerializeField] private Button _rightPageButton;

        private ITabNavigation _navigation;
        private RectTransform _transform;

        private bool _isOpened;
        private int _page;

        private CancellationTokenSource _pagesCancellation;
        private CancellationTokenSource _dataWindowCancellation;

        private AchievementsPage _currentPage;
        private IReadOnlyList<AchievementsPage> _pages;
        private int _totalPagesCount;

        public ITabNavigation Navigation => _navigation;
        public RectTransform Transform => _transform;

        private void Awake()
        {
            _navigation = GetComponent<ITabNavigation>();
            _transform = GetComponent<RectTransform>();
        }

        public void Enable()
        {
            _leftPageButton.onClick.AddListener(OnLeftPageClicked);
            _rightPageButton.onClick.AddListener(OnRightPageClicked);

            CancelPage();

            foreach (var entry in _entries)
                entry.Selected += OnAchievementSelected;

            foreach (var entry in _entries)
                entry.Deselected += OnAchievementDeselected;
        }

        public void Disable()
        {
            _leftPageButton.onClick.RemoveListener(OnLeftPageClicked);
            _rightPageButton.onClick.RemoveListener(OnRightPageClicked);

            _isOpened = false;
            _currentPage = null;

            CancelPage();

            foreach (var entry in _entries)
                entry.Selected -= OnAchievementSelected;

            foreach (var entry in _entries)
                entry.Deselected -= OnAchievementDeselected;
        }

        public void Construct(IReadOnlyList<IAchievement> achievements)
        {
            var pages = new List<AchievementsPage>();
            _totalPagesCount = Mathf.CeilToInt(achievements.Count / (float)_entries.Length);

            for (var i = 0; i < _totalPagesCount; i++)
            {
                var pagePoint = Instantiate(_pagePointPrefab, _pagePointsRoot);

                var start = i * _entries.Length;
                var pagesAchievements = new List<IAchievement>();
                var counter = 0;

                while (counter < _entries.Length && start + counter < achievements.Count)
                {
                    var index = start + counter;
                    pagesAchievements.Add(achievements[index]);

                    counter++;
                }

                var page = new AchievementsPage(pagesAchievements, _entries, pagePoint);
                pages.Add(page);
            }

            _pages = pages;
        }

        public async UniTask Open()
        {
            foreach (var page in _pages)
                page.DeactivatePage();

            _page = 0;
            CancelPage();
            _pagesCancellation = new CancellationTokenSource();
            await ShowPage(_page, _pagesCancellation.Token);
        }

        private void OnLeftPageClicked()
        {
            _page--;
            CancelPage();
            CancelDataWindow();
            _pagesCancellation = new CancellationTokenSource();
            ShowPage(_page, _pagesCancellation.Token).Forget();
        }

        private void OnRightPageClicked()
        {
            _page++;
            CancelPage();
            CancelDataWindow();
            _pagesCancellation = new CancellationTokenSource();
            ShowPage(_page, _pagesCancellation.Token).Forget();
        }

        private async UniTask ShowPage(int page, CancellationToken cancellation)
        {
            if (page == 0)
                _leftPageButton.gameObject.SetActive(false);
            else
                _leftPageButton.gameObject.SetActive(true);

            if (page >= _totalPagesCount - 1)
                _rightPageButton.gameObject.SetActive(false);
            else
                _rightPageButton.gameObject.SetActive(true);

            var previousPage = _currentPage;
            _currentPage = _pages[page];

            _currentPage.ActivatePage();

            if (previousPage != null && _isOpened == true)
            {
                previousPage.DeactivatePage();
                await previousPage.Hide(cancellation);
            }

            _isOpened = true;

            await _currentPage.Show(cancellation);
        }

        private void CancelPage()
        {
            _pagesCancellation?.Cancel();
            _pagesCancellation?.Dispose();
            _pagesCancellation = null;
        }
        
        private void CancelDataWindow()
        {
            _dataWindowCancellation?.Cancel();
            _dataWindowCancellation?.Dispose();
            _dataWindowCancellation = null;
        }

        private void OnAchievementSelected(IAchievement achievement)
        {
            CancelDataWindow();
            _dataWindowCancellation = new CancellationTokenSource();
            _dataWindow.Show(achievement, _dataWindowCancellation.Token).Forget();
        }

        private void OnAchievementDeselected()
        {
            CancelDataWindow();
            _dataWindowCancellation = new CancellationTokenSource();
            _dataWindow.Hide(_dataWindowCancellation.Token).Forget();
        }
    }
}