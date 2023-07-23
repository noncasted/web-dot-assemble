using System;
using UnityEngine;

namespace Global.Services.Inputs.View.Runtime.Movement
{
    public interface IMovementInputView
    {
        event Action<Vector2> MovementPerformed;
        event Action MovementCanceled;
    }
}