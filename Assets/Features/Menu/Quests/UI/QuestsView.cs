using UnityEngine;

namespace Menu.Quests.UI
{
    [DisallowMultipleComponent]
    public class QuestsView : MonoBehaviour, IQuestsView
    {
        public RectTransform Transform { get; private set; }

        private void Awake()
        {
            Transform = GetComponent<RectTransform>();
        }
    }
}