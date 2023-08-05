namespace GamePlay.Level.Services.AssembleCheck.Runtime
{
    public readonly struct CheckResult
    {
        public CheckResult(int destroyedAmount)
        {
            DestroyedAmount = destroyedAmount;
        }
        
        public readonly int DestroyedAmount;
    }
}