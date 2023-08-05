using GamePlay.UI.Runtime.Score;
using UnityEngine;

namespace GamePlay.UI.Runtime
{
    [DisallowMultipleComponent]
    public class LevelUiLinker : MonoBehaviour
    {
        [SerializeField] private ScoreView _score;

        public ScoreView Score => _score;
    }
}