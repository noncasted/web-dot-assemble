﻿using Global.Publisher.Abstract.Purchases;
using UnityEngine;

namespace Global.LevelConfiguration.Avatars
{
    public interface IAvatarDefinition
    {
        Sprite Sprite { get; }
        IProductLink Product { get; }
    }
}