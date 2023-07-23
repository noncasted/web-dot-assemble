using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;
using Global.Services.Inputs.Constranits.Definition;

namespace Global.Services.Inputs.Constranits.Storage
{
    [Serializable]
    public class InputConstraintsDictionary : ReadOnlyDictionary<InputConstraints, bool>
    {
    }
}