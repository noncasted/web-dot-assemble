﻿using UnityEngine;

namespace Global.Services.Inputs.View.Runtime.Conversion
{
    public interface IInputConversion
    {
        Vector2 ScreenToWorld(Vector2 position);
    }
}