using UnityEngine;

namespace Menu.Quests.UI
{
    [DisallowMultipleComponent]
    public class QuestsView : MonoBehaviour, IQuestsView
    {
        private RectTransform _transform;

        public RectTransform Transform => _transform;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
        }
    }
}