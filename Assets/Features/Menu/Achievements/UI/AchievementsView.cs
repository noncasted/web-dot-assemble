using UnityEngine;

namespace Menu.Achievements.UI
{
    [DisallowMultipleComponent]
    public class AchievementsView : MonoBehaviour, IAchievementsView
    {
        private RectTransform _transform;

        public RectTransform Transform => _transform;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
        }
    }
}