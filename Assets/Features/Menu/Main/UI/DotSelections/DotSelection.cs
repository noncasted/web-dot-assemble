using GamePlay.Level.Dots.Definitions;
using UnityEngine;

namespace Menu.Main.UI.DotSelections
{
    [DisallowMultipleComponent]
    public class DotSelection : MonoBehaviour, IDotSelection
    {
        [SerializeField] private DotSelectionMenu _menu;
        
        public void Construct(IDotDefinitionsStorage dotDefinitionsStorage)
        {
            _menu.Construct(dotDefinitionsStorage);
        }
    }
}