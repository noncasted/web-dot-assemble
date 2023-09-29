using System;
using Common.UI.Buttons;
using UnityEngine;

namespace Menu.Leaderboards.UI
{
    public class LeaderboardButtonsView : MonoBehaviour, ILeaderboardButtonsView
    {
        [SerializeField] private ExtendedButton _previousButton;
        [SerializeField] private ExtendedButton _nextButton;
        
        public event Action NextClicked;
        public event Action PreviousClicked;

        private void OnEnable()
        {
            _previousButton.Clicked += OnPreviousClicked;
            _nextButton.Clicked += OnNextClicked;
        }

        private void OnDisable()
        {
            _previousButton.Clicked -= OnPreviousClicked;
            _nextButton.Clicked -= OnNextClicked;
        }

        private void OnPreviousClicked()
        {
            PreviousClicked?.Invoke();
        }
        
        private void OnNextClicked()
        {
            NextClicked?.Invoke();
        }
    }
}