using UnityEngine;

namespace Menu.Leaderboards.UI
{
    [DisallowMultipleComponent]
    public class LeaderboardsView : MonoBehaviour, ILeaderboardsView
    {
        public RectTransform Transform { get; private set; }

        private void Awake()
        {
            Transform = GetComponent<RectTransform>();
        }
    }
}