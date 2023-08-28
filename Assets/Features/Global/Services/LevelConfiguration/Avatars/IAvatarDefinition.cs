using UnityEngine;

namespace Global.LevelConfiguration.Avatars
{
    public interface IAvatarDefinition
    {
        int Id { get; }
        Sprite Sprite { get; }

        void SetId(int id);
    }
}