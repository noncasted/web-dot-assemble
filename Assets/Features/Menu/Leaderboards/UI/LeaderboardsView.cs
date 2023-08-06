using UnityEngine;

namespace Menu.Leaderboards.UI
{
    [DisallowMultipleComponent]
    public class LeaderboardsView : MonoBehaviour, ILeaderboardsView
    {
        private RectTransform _transform;

        public RectTransform Transform => _transform;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
        }
    }
}