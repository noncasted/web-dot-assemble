using Global.LevelConfigurations.Avatars;
using Global.LevelConfigurations.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.LevelConfigurations.Definition
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelConfigurationRoutes.ConfigName,
        menuName = LevelConfigurationRoutes.ConfigPath)]
    public class LevelConfiguration : ScriptableObject, ILevelConfiguration
    {
        [SerializeField] private AvatarDefinition _enemy;
        [SerializeField] [Min(0)] private int _targetScore;

        public IAvatarDefinition Enemy => _enemy;
        public int TargetScore => _targetScore;
    }
}