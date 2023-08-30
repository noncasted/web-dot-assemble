using Global.Audio.Player.Runtime;
using Global.Localizations.Runtime;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Settings.UI
{
    public class SettingsController : ISettingsController, ITab
    {
        public SettingsController(
            ISettingsView view,
            IVolumeSetter volumeSetter,
            ILanguageConverter languageConverter,
            ILocalization localization)
        {
            _view = view;
            _volumeSetter = volumeSetter;
            _languageConverter = languageConverter;
            _localization = localization;
        }

        private readonly ISettingsView _view;
        private readonly IVolumeSetter _volumeSetter;
        private readonly ILanguageConverter _languageConverter;
        private readonly ILocalization _localization;

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
            _volumeSetter.SetVolume(_view.MusicValue, _view.SoundValue);
            _volumeSetter.SaveVolume();
        }

        private void OnLanguageClicked()
        {
        }

        private void OnSocialClicked()
        {
        }
    }
}