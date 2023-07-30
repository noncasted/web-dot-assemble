namespace GamePlay.Level.Dots.Runtime.LifeFlow
{
    public class DotLifeFlowConfig : IDotLifeFlowConfig
    {
        public DotLifeFlowConfig(int maxSize)
        {
            _maxSize = maxSize;
        }

        private readonly int _maxSize;

        public int MaxCycle => _maxSize;
    }
}