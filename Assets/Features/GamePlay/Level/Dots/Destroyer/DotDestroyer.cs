using Cysharp.Threading.Tasks;
using GamePlay.Level.Dots.Runtime;
using GamePlay.Level.Fields.Runtime;
using UnityEngine;

namespace GamePlay.Level.Dots.Destroyer
{
    public class DotDestroyer : IDotDestroyer
    {
        private readonly IField _field;

        public DotDestroyer(IField field)
        {
            _field = field;
        }

        public async UniTask Destroy(IDot dot)
        {
            dot.Disable();
            _field.RemoveDot(dot);
            await dot.Destroy();
            Object.Destroy(dot.View.Transform.gameObject);
        }
    }
}