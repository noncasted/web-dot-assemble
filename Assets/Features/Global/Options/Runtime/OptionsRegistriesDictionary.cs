using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.Options.Runtime
{
    [Serializable]
    public class OptionsRegistriesDictionary : ReadOnlyDictionary<EnvironmentType, OptionsRegistry>
    {
    }
}