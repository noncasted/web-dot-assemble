using System;
using Common.Serialization.SerializableDictionaries;
using UnityEngine.UI;

namespace Menu.Common.Navigation
{
    [Serializable]
    public class NavigationDictionary : SerializableDictionary<Button, NavigationEntry>
    {
        
    }
}