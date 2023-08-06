using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Settings.UI
{
    public class SettingsController : ISettingsController, ITab
    {
        public SettingsController(ISettingsView view)
        {
            _view = view;
        }

        private readonly ISettingsView _view;

        public RectTransform Transform => _view.Transform;
        
        public void Activate()
        {
            
        }

        public void Deactivate()
        {
            
        }
    }
}