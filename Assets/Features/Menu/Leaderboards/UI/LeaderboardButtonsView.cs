using UnityEngine;
using UnityEngine.UI;
using Action = Unity.Plastic.Newtonsoft.Json.Serialization.Action;

namespace Menu.Leaderboards.UI
{
    public class LeaderboardButtonsView : MonoBehaviour, ILeaderboardButtonsView
    {
        [SerializeField] private Button _previousButton;
        [SerializeField] private Button _nextButton;
        
        public event Action NextClicked;
        public event Action PreviousClicked;

        private void OnEnable()
        {
            _previousButton.onClick.AddListener(OnPreviousClicked);
            _nextButton.onClick.AddListener(OnNextClicked);
        }

        private void OnDisable()
        {
            _previousButton.onClick.RemoveListener(OnPreviousClicked);
            _nextButton.onClick.RemoveListener(OnNextClicked);
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