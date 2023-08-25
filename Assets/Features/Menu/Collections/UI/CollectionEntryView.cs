using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Menu.Collections.Global;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Collections.UI
{
    public class CollectionEntryView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private CollectionEntryViewConfig _config;

        public async UniTask Show(AvatarHandle avatar, CancellationToken cancellation)
        {
            _icon.sprite = avatar.Definition.Sprite;
            
            await transform
                .DOScale(Vector3.one, _config.ShowTime)
                .SetEase(Ease.InCirc)
                .Play()
                .ToUniTask(TweenCancelBehaviour.Kill, cancellation);
        }

        public async UniTask Hide(CancellationToken cancellation)
        {
            await transform
                .DOScale(Vector3.zero, _config.HideTime)
                .SetEase(Ease.OutExpo)
                .Play()
                .ToUniTask(TweenCancelBehaviour.Kill, cancellation);
        }
    }
}