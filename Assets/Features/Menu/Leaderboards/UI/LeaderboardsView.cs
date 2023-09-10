using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Leaderboards;
using Menu.Common.Navigation;
using Menu.Leaderboards.Global;
using TMPro;
using UnityEngine;

namespace Menu.Leaderboards.UI
{
    [DisallowMultipleComponent]
    public class LeaderboardsView : MonoBehaviour, ILeaderboardsView
    {
        [SerializeField] [Min(0f)] private float _showDelay = 0.05f;

        [SerializeField] private RectTransform _root;
        [SerializeField] private RectTransform _separator;
        [SerializeField] private LeaderboardEntry _entryPrefab;
        [SerializeField] private List<LeaderboardEntry> _all;
        [SerializeField] private TMP_Text _tableTitle;
        [SerializeField] private LeaderboardButtonsView _buttons;
        
        private IReadOnlyList<LeaderboardEntry> _allActive;
        private IReadOnlyList<LeaderboardEntry> _top;
        private IReadOnlyList<LeaderboardEntry> _around;

        private ITabNavigation _navigation;
        private RectTransform _transform;

        public ITabNavigation Navigation => _navigation;
        public RectTransform Transform => _transform;
        public ILeaderboardButtonsView Buttons => _buttons;

        private void Awake()
        {
            _navigation = GetComponent<ITabNavigation>();
            _transform = GetComponent<RectTransform>();
        }

        public async UniTask Show(IReadOnlyList<LeaderboardUser> users, LeaderboardTableEntryData data, CancellationToken cancellation)
        {
            _tableTitle.text = data.Text.GetText();
            var isInAround = false;
            var previousRank = users[0].Rank;

            var top = new List<LeaderboardUser>();
            var around = new List<LeaderboardUser>();

            foreach (var user in users)
            {
                if (user.Rank > previousRank + 1)
                    isInAround = true;

                if (isInAround == true)
                    around.Add(user);
                else
                    top.Add(user);

                previousRank = user.Rank;
            }

            AddIfRequired(_all, top.Count + around.Count);

            var currentUsers = new List<LeaderboardUser>();
            var currentEntries = new List<LeaderboardEntry>();

            currentUsers.AddRange(top);
            currentUsers.AddRange(around);

            _separator.transform.SetSiblingIndex(_separator.transform.childCount);
            _separator.transform.SetSiblingIndex(top.Count);

            for (var i = 0; i < currentUsers.Count; i++)
                currentEntries.Add(_all[i]);

            var showTasks = new UniTask[currentUsers.Count];
            _allActive = currentEntries;

            for (var i = 0; i < _all.Count; i++)
            {
                if (i < _allActive.Count)
                    _all[i].Enable();
                else
                    _all[i].Disable();
            }

            for (var i = 0; i < _allActive.Count; i++)
            {
                showTasks[i] = _allActive[i].Show(currentUsers[i], cancellation);
                await UniTask.Delay(_showDelay, cancellation);
            }

            await UniTask.WhenAll(showTasks);
        }

        public async UniTask Hide(CancellationToken cancellation)
        {
            if (_allActive == null)
                return;

            var hideTasks = new UniTask[_allActive.Count];

            for (var i = 0; i < _allActive.Count; i++)
            {
                hideTasks[i] = _allActive[i].Hide(cancellation);
                await UniTask.Delay(_showDelay, cancellation);
            }
        }

        public void HideInstant()
        {
            foreach (var entry in _all)
                entry.Disable();
        }

        private void AddIfRequired(List<LeaderboardEntry> target, int requiredAmount)
        {
            if (target.Count >= requiredAmount)
                return;

            var delta = requiredAmount - target.Count;

            for (var i = 0; i < delta; i++)
            {
                var entry = Instantiate(_entryPrefab, _root);
                target.Add(entry);
            }
        }
    }
}