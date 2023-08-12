using UnityEngine;

namespace Global.Services.LevelConfiguration.Avatars
{
    public interface IAvatarDefinition
    {
        int Id { get; }
        Sprite Sprite { get; }
    }
}