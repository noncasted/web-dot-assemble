using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Menu.Achievements.Definitions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Achievements.UI
{
    [DisallowMultipleComponent]
    public class AchievementDataWindow : MonoBehaviour
    {
        [SerializeField] private float _switchSpeed = 1f;
        [SerializeField] private float _barDelay = 0.5f;
        
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private AchievementProgressBar _progressBar;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public async UniTask Show(IAchievement achievement, CancellationToken cancellation)
        {
            gameObject.SetActive(true);
            cancellation.Register(() => gameObject.SetActive(false));
            transform.localScale = Vector3.zero;

            _name.text = achievement.Data.Name;
            _description.text = achievement.Data.Description;
            _icon.sprite = achievement.Data.Icon;
            
            await transform
                .DOScale(Vector3.one, _switchSpeed)
                .SetEase(Ease.InCirc)
                .Play()
                .ToUniTask(TweenCancelBehaviour.Kill, cancellation);

            await UniTask.Delay(_barDelay);
            
            var progress = achievement.Progress.Value / (float) achievement.Progress.Target;
            await _progressBar.UpdateProgress(progress, cancellation);
        }
        
        public async UniTask Hide(CancellationToken cancellation)
        {
            cancellation.Register(() => gameObject.SetActive(false));

            await transform
                .DOScale(Vector3.zero, _switchSpeed)
                .SetEase(Ease.InCirc)
                .Play()
                .ToUniTask(TweenCancelBehaviour.Kill, cancellation);
        }
    }
}