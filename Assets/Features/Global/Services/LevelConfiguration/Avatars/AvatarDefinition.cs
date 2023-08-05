using Global.Services.LevelConfiguration.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.LevelConfiguration.Avatars
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelConfigurationRoutes.AvatarName,
        menuName = LevelConfigurationRoutes.AvatarPath)]
    public class AvatarDefinition : ScriptableObject, IAvatarDefinition
    {
        [SerializeField] private Sprite _sprite;

        public Sprite Sprite => _sprite;
    }
}