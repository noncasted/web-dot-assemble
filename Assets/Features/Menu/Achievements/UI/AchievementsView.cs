using Features.Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Achievements.UI
{
    [DisallowMultipleComponent]
    public class AchievementsView : MonoBehaviour, IAchievementsView
    {
        [SerializeField] private TabNavigation _tabNavigation;

        public ITabNavigation Navigation => _tabNavigation;
        public RectTransform Transform { get; private set; }

        private void Awake()
        {
            Transform = GetComponent<RectTransform>();
        }
    }
}