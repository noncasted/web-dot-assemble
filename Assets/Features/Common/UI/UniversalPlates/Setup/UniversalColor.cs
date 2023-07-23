using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UI.UniversalPlates.Setup
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Color_", menuName = "UI/Color")]
    public class UniversalColor : ScriptableObject
    {
        [SerializeField] [Indent] private Color _value;

        public Color Value => _value;
    }
}