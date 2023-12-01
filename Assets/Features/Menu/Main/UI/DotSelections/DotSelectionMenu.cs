using System.Collections.Generic;
using GamePlay.Level.Dots.Definitions;
using UnityEngine;

namespace Menu.Main.UI.DotSelections
{
    [DisallowMultipleComponent]
    public class DotSelectionMenu : MonoBehaviour
    {
        private IDotDefinitionsStorage _dotDefinitionsStorage;

        public void Construct(IDotDefinitionsStorage dotDefinitionsStorage)
        {
            _dotDefinitionsStorage = dotDefinitionsStorage;
        }

        public void Open(IReadOnlyList<IDotDefinition> currentSelected)
        {
            
        }
    }
}