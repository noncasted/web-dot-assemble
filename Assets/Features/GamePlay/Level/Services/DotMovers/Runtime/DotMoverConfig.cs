using GamePlay.Level.Services.DotMovers.Common;
using NaughtyAttributes;
using UnityEngine;

namespace GamePlay.Level.Services.DotMovers.Runtime
{
    [CreateAssetMenu(fileName = DotMoverRoutes.ConfigName,
        menuName = DotMoverRoutes.ConfigPath)]
    public class DotMoverConfig : ScriptableObject, IDotMoverConfig
    {
        [SerializeField] [Min(0f)] private float _bounceDistance;
        [SerializeField] [Min(0f)] private float _bounceTime;
        [SerializeField] [Min(0f)] private float _stepTime;

        [SerializeField] [CurveRange(0f, 0f, 1f, 1f)]
        private AnimationCurve _curve;

        public float BounceDistance => _bounceDistance;
        public float BounceTime => _bounceTime;
        public float StepTime => _stepTime;
        public AnimationCurve Curve => _curve;
    }
}