using UnityEngine;

namespace GamePlay.Level.Services.DotMovers.Runtime
{
    public interface IDotMoverConfig
    {
        float BounceDistance { get; }
        float BounceTime { get; }
        float StepTime { get; }
        AnimationCurve Curve { get; }
    }
}