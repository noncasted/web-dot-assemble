using Common.UI.UiTools.Common;
using UnityEngine;

namespace Common.UI.UiTools.ButtonReponses
{
    [CreateAssetMenu(fileName = UiToolsRoutes.ButtonResponseName,
        menuName = UiToolsRoutes.ButtonResponsePath)]
    public class ButtonResponseConfig : ScriptableObject
    {
        [SerializeField] private float _overSize = 1.1f;
        [SerializeField] private float _switchTime = 0.3f;

        public float OverSize => _overSize;
        public float SwitchTime => _switchTime;
    }
}