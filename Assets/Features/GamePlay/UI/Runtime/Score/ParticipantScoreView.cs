using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.UI.Runtime.Score
{
    [DisallowMultipleComponent]
    public class ParticipantScoreView : MonoBehaviour
    {
        [SerializeField] private Image _avatar;
        [SerializeField] private TMP_Text _score;
        [SerializeField] private RectTransform _pillowTransform;

        [SerializeField] private float _scaleTime = 1f;
        [SerializeField] private float _minSize = 200f;

        private float _startSize;

        private void Awake()
        {
            _startSize = _pillowTransform.sizeDelta.y;
        }

        public void SetAvatar(Sprite avatar)
        {
            _avatar.sprite = avatar;
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void SetScorePermanent(int score)
        {
            _score.text = score.ToString();
        }
        
        public async UniTask SetScore(int score, float targetProgress, CancellationToken cancellationToken)
        {
            _score.text = score.ToString();
            
            targetProgress = Mathf.Clamp01(targetProgress);
            
            var startSize = _pillowTransform.sizeDelta.y;
            var targetSize = (_startSize - _minSize) * targetProgress;
            
            var progress = 0f;
            var time = 0f;

            while (progress < 1f)
            {
                time += Time.deltaTime;
                progress = time / _scaleTime;
                
                var size = _pillowTransform.sizeDelta;
                size.y = Mathf.Lerp(startSize, _minSize + targetSize, progress);

                if (size.y < _minSize)
                    size.y = _minSize;
                
                _pillowTransform.sizeDelta = size;
                
                await UniTask.Yield(cancellationToken);
            }
        }
    }
}