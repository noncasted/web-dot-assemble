using Menu.Leaderboards.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Leaderboards.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LeaderboardsRoutes.ConfigName, menuName = LeaderboardsRoutes.ConfigPath)]
    public class LeaderboardsConfig : ScriptableObject, ILeaderboardsConfig
    {
        [SerializeField] private int _quantityTop;
        [SerializeField] private int _quantityAround;

        public int QuantityTop => _quantityTop;
        public int QuantityAround => _quantityAround; 
    }
}