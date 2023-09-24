using Global.LevelConfigurations.Common;
using Global.Publisher.Abstract.Purchases;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.LevelConfigurations.Avatars
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelConfigurationRoutes.AvatarName,
        menuName = LevelConfigurationRoutes.AvatarPath)]
    public class AvatarDefinition : ScriptableObject, IAvatarDefinition
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private ProductLink _product;

        public Sprite Sprite => _sprite;
        public IProductLink Product => _product;
    }
}