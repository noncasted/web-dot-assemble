using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.UI.UniversalPlates.Runtime.Plate.Hover
{
    public class HoverTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] [ReadOnly] private bool _isHovered;

        public bool IsHovered => _isHovered;

        private void OnDisable()
        {
            _isHovered = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _isHovered = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _isHovered = false;
        }
    }
}