using System.Threading;
using Cysharp.Threading.Tasks;
using Global.System.ApplicationProxies.Runtime;
using UnityEngine;

namespace GamePlay.UI.Runtime.Score
{
    public interface ILevelUiView
    {
        void HidePillows();
        UniTask UpdateScore(int player, int enemy, ScreenMode screenMode, CancellationToken cancellation);
        void UpdateAvatars(Sprite player, Sprite enemy);
    }
}