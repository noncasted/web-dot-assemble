using Menu.Achievements.Definitions;
using TMPro;
using UnityEngine;

namespace Menu.Achievements.UI
{
    [DisallowMultipleComponent]
    public class AchievementDataWindow : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private AchievementProgressBar _progressBar;
        
        public void Show(IAchievement achievement)
        {
            _name.text = achievement.Data.Name;
        }
    }
}