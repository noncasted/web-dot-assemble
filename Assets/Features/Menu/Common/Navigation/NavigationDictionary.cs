using System;
using Common.Serialization.SerializableDictionaries;
using UnityEngine.UI;

namespace Features.Menu.Common.Navigation
{
    [Serializable]
    public class NavigationDictionary : SerializableDictionary<Button, NavigationEntry>
    {
        
    }
}