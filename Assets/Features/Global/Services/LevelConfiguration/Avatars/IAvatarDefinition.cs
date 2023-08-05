using UnityEngine;

namespace Features.Global.Services.LevelConfiguration.Avatars
{
    public interface IAvatarDefinition
    {
        Sprite Sprite { get; }
    }
}