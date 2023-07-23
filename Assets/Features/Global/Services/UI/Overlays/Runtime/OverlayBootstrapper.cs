using UnityEngine;

namespace Global.Services.UI.Overlays.Runtime
{
    [DisallowMultipleComponent]
    public class OverlayBootstrapper : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour[] _eventListeners;

        public MonoBehaviour[] EventListeners => _eventListeners;
    }
}