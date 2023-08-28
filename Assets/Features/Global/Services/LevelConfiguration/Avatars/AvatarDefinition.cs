using Global.LevelConfiguration.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.LevelConfiguration.Avatars
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelConfigurationRoutes.AvatarName,
        menuName = LevelConfigurationRoutes.AvatarPath)]
    public class AvatarDefinition : ScriptableObject, IAvatarDefinition
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _id;

        public int Id => _id;   
        public Sprite Sprite => _sprite;
        
        public void SetId(int id)
        {
            _id = id;
        }
    }
}