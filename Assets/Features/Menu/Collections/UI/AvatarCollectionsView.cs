using UnityEngine;

namespace Menu.Collections.UI
{
    [DisallowMultipleComponent]
    public class AvatarCollectionsView : MonoBehaviour, IAvatarCollectionsView
    {
        private RectTransform _transform;

        public RectTransform Transform => _transform;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
        }
    }
}