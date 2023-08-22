using System.Collections.Generic;
using System.Threading;
using Common.Architecture.Local.Services.Abstract.Callbacks;
using Cysharp.Threading.Tasks;
using Menu.Achievements.Definitions;
using Menu.Common.Navigation;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Achievements.UI
{
    [DisallowMultipleComponent]
    public class AchievementsView : MonoBehaviour, IAchievementsView, ILocalSwitchListener
    {
        [SerializeField] private AchievementEntryView[] _entries;
        
        [SerializeField] private Button _leftPageButton;
        [SerializeField] private Button _rightPageButton;
        
        private ITabNavigation _navigation;
        private RectTransform _transform;

        private int _page;
        private int _totalPagesCount;
        
        private IReadOnlyList<IAchievement> _achievements;

        public ITabNavigation Navigation => _navigation;
        public RectTransform Transform => _transform;

        private void Awake()
        {
            _navigation = GetComponent<ITabNavigation>();
            _transform = GetComponent<RectTransform>();
        }
        
        public void OnEnabled()
        {
            _leftPageButton.onClick.AddListener(OnLeftPageClicked);
            _rightPageButton.onClick.AddListener(OnRightPageClicked);
        }
        
        public void OnDisabled()
        {
            _leftPageButton.onClick.RemoveListener(OnLeftPageClicked);
            _rightPageButton.onClick.RemoveListener(OnRightPageClicked);
        }
        
        public void Construct(IReadOnlyList<IAchievement> achievement)
        {
            _achievements = achievement;
            _totalPagesCount = achievement.Count / _entries.Length;
        }

        public async UniTask Open(CancellationToken cancellation)
        {
            _page = 0;
            await ShowPage(_page, cancellation);
        }

        private void OnLeftPageClicked()
        {
            _page--;
            ShowPage(_page, this.GetCancellationTokenOnDestroy()).Forget();
        }
        
        private void OnRightPageClicked()
        {
            _page++;
            ShowPage(_page, this.GetCancellationTokenOnDestroy()).Forget();
        }

        private async UniTask ShowPage(int page, CancellationToken cancellation)
        {
            if (page == 0)
                _leftPageButton.gameObject.SetActive(false);
            else
                _leftPageButton.gameObject.SetActive(true);
            
            if (page == _totalPagesCount)
                _rightPageButton.gameObject.SetActive(false);
            else
                _rightPageButton.gameObject.SetActive(true);

            var start = page * _entries.Length;
            var lastIndex = 0;

            if (start + _entries.Length >= _achievements.Count)
                lastIndex = _achievements.Count;
            else
                lastIndex = start + _entries.Length;

            var entryCounter = 0;

            for (var i = start; i < lastIndex; i++)
            {
                _entries[entryCounter].Construct(_achievements[i]);
                entryCounter++;
            }

            var list = new List<UniTask>();
            
            foreach (var entry in _entries)
            {
                var task = entry.Show(cancellation);
                list.Add(task);

                await UniTask.Yield(cancellation);
            }

            await UniTask.WhenAll(list);
        }
    }
}