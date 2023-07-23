using UnityEngine;

namespace GamePlay.Common.Damages
{
    public readonly struct Damage
    {
        public Damage(int amount, float pushForce, Vector2 direction)
        {
            Amount = amount;
            PushForce = pushForce;
            Direction = direction;
        }

        public readonly int Amount;
        public readonly float PushForce;
        public readonly Vector2 Direction;
    }
}