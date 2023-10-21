using System.Collections.Generic;
using GamePlay.Level.Dots.Definitions;
using UnityEngine;

namespace Menu.Main.UI.DotSelection
{
    [DisallowMultipleComponent]
    public class BallSelectionMenu : MonoBehaviour
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