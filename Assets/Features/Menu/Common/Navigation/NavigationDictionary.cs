using System;
using Common.Serialization.SerializableDictionaries;
using Common.UI.Extended.Buttons;
using UnityEngine.UI;

namespace Menu.Common.Navigation
{
    [Serializable]
    public class NavigationDictionary : SerializableDictionary<ExtendedButton, NavigationEntry>
    {
        
    }
}