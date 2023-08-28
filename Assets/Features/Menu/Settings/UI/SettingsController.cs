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
            _view.Navigation.Enable();
            
            _view.LanguageClicked += OnLanguageClicked;
            _view.SocialClicked += OnSocialClicked;
        }

        public void Deactivate()
        {
            _view.Navigation.Disable();
        }

        private void OnLanguageClicked()
        {
            
        }

        private void OnSocialClicked()
        {
            
        }
    }
}