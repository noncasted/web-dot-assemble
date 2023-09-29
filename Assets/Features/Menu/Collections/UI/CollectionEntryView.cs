using System.Threading;
using Cysharp.Threading.Tasks;
using Menu.Collections.Global;
using Menu.Common.Pages;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Collections.UI
{
    public class CollectionEntryView : PageEntry<AvatarHandle>
    {
        [SerializeField] private Image _icon;
        [SerializeField] private CollectionEntryViewConfig _config;

        public override async UniTask Show(AvatarHandle avatar, CancellationToken cancellation)
        {
            _icon.sprite = avatar.Definition.Sprite;
        }

        public override async UniTask Hide(CancellationToken cancellation)
        {
        }
    }
}