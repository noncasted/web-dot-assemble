using UnityEngine;

namespace Menu.Achievements.UI
{
    [DisallowMultipleComponent]
    public class AchievementProgressBar : MonoBehaviour
    {
        [SerializeField] private RectTransform _transform;

        private float _startX;

        private void Awake()
        {
            _startX = _transform.offsetMax.x;
        }

        public void UpdateProgress(float progress)
        {
            var offset = _transform.offsetMax;
            offset.x = Mathf.Lerp(_startX, 0f, progress);
            _transform.offsetMax = offset;
        }
    }
}