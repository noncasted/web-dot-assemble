using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UI.UniversalPlates.Extended.Texts
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "AnimatedText", menuName = "UI/Config/AnimatedText")]
    public class AnimatedTextConfig : ScriptableObject
    {
        [SerializeField] [Min(0f)] private float _switchTime;

        public float SwitchTime => _switchTime;
    }
}