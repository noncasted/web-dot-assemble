using System;
using Common.Serialization.SerializableDictionaries;
using Common.UI.Extended.Buttons;

namespace Menu.Common.Navigation
{
    [Serializable]
    public class NavigationDictionary : SerializableDictionary<ExtendedButton, NavigationEntry>
    {
        
    }
}