using UnityEngine;

namespace Common.UI.UniversalPlates.Buttons
{
    [CreateAssetMenu(fileName = "UniversalButtonConfig", menuName = "UI/Config/Button")]
    public class UniversalButtonConfig : ScriptableObject
    {
        [SerializeField] private float _switchTime;

        public float SwitchTime => _switchTime;
    }
}