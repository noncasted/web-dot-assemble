using UnityEngine;

namespace Menu.Achievements.UI
{
    [DisallowMultipleComponent]
    public class AchievementPagePointView : MonoBehaviour
    {
        [SerializeField] private GameObject _active;
        [SerializeField] private GameObject _deactivated;
        
        public void Activate()
        {
            _active.SetActive(true);
            _active.SetActive(false);
        }

        public void Deactivate()
        {
            _active.SetActive(false);
            _active.SetActive(true);
        }
    }
}