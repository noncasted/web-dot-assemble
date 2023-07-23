using System.Collections.Generic;
using Global.Services.Inputs.Constranits.Definition;
using Global.Services.Inputs.Constranits.Storage;
using Global.Services.UI.UiStateMachines.Common;
using UnityEngine;

namespace Global.Services.UI.UiStateMachines.Runtime
{
    [CreateAssetMenu(fileName = UiStateMachineRouter.ConstraintsPrefix,
        menuName = UiStateMachineRouter.ConstraintsPath)]
    public class UiConstraints : ScriptableObject
    {
        [SerializeField] private InputConstraintsDictionary _input;

        public IReadOnlyDictionary<InputConstraints, bool> Input => _input;
    }
}