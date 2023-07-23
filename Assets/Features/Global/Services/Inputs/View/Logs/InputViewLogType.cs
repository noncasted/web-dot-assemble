namespace Global.Services.Inputs.View.Logs
{
    public enum InputViewLogType
    {
        RollPressed,
        RollCanceled,

        MovementPressed,
        MovementCanceled,

        RangeAttackPerformed,
        RangeAttackCanceled,

        MeleeAttackPerformed,
        MeleeAttackCanceled,

        BeforeRebind,
        AfterRebind,

        ConstraintAdded,
        ConstraintReduced,
        ConstraintRemoved,
        ConstraintBelowZeroException,
        InputCanceledWithConstraint
    }
}