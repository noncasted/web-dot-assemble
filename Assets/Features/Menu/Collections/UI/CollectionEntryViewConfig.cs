using Menu.Collections.Common;
using UnityEngine;

namespace Menu.Collections.UI
{
    [CreateAssetMenu(fileName = CollectionsRoutes.EntryViewConfigName,
        menuName = CollectionsRoutes.EntryViewConfigPath)]
    public class CollectionEntryViewConfig : ScriptableObject
    {
        [SerializeField] [Min(0f)] private float _showTime;
        [SerializeField] [Min(0f)] private float _hideTime;

        public float ShowTime => _showTime;
        public float HideTime => _hideTime;
    }
}