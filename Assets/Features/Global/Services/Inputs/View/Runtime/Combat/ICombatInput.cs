using System;

namespace Global.Services.Inputs.View.Runtime.Combat
{
    public interface ICombatInput
    {
        event Action RangeAttackPerformed;
        event Action RangeAttackCanceled;
        
        event Action MeleeAttackPerformed;
        event Action MeleeAttackCanceled;
    }
}