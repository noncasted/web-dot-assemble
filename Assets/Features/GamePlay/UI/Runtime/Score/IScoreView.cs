using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.UI.Runtime.Score
{
    public interface IScoreView
    {
        UniTask UpdateScore(int player, int enemy, CancellationToken cancellationToken);
        void UpdateAvatars(Sprite player, Sprite enemy);
    }
}