using System.Threading;
using Cysharp.Threading.Tasks;
using Menu.Leaderboards.Global;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Leaderboards.UI
{
    public class LeaderboardsController : ILeaderboardsController, ITab
    {
        public LeaderboardsController(
            ILeaderboardsView view,
            ILeaderboards leaderboards,
            LeaderboardsTableEntriesConfig entriesConfig)
        {
            _view = view;
            _leaderboards = leaderboards;
            _entriesConfig = entriesConfig;
        }

        
        private readonly ILeaderboardsView _view;
        private readonly ILeaderboards _leaderboards;
        private readonly LeaderboardsTableEntriesConfig _entriesConfig;

        private LeaderboardTableEntryData _currentTable;
        private CancellationTokenSource _cancellation;

        public RectTransform Transform => _view.Transform;
        
        public void Activate()
        {
            _view.Navigation.Enable();
            _view.HideInstant();
            
            _view.Buttons.NextClicked += OnNextClicked;
            _view.Buttons.PreviousClicked += OnPreviousClicked;
            
            Cancel();
            _cancellation = new CancellationTokenSource();
            _currentTable = _entriesConfig.First(); 
            Show(_currentTable).Forget();
        }

        public void Deactivate()
        {
            _view.Navigation.Disable();
            Cancel();
        }

        private async UniTaskVoid Show(LeaderboardTableEntryData data)
        {
            var users = await _leaderboards.Get(data, _cancellation.Token);
            await _view.Show(users, data, _cancellation.Token);
        }
        
        private async UniTaskVoid Switch(LeaderboardTableEntryData data)
        {
            var users = await _leaderboards.Get(data, _cancellation.Token);
            await _view.Hide(_cancellation.Token);
            await _view.Show(users, data, _cancellation.Token);
        }

        private void Cancel()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
        
        private void OnPreviousClicked()
        {
            _currentTable = _entriesConfig.Previous(_currentTable);
            
            Cancel();
            _cancellation = new CancellationTokenSource();
            Switch(_currentTable).Forget();
        }

        private void OnNextClicked()
        {
            _currentTable = _entriesConfig.Next(_currentTable);
            
            Cancel();
            _cancellation = new CancellationTokenSource();
            Switch(_currentTable).Forget();
        }
    }
}