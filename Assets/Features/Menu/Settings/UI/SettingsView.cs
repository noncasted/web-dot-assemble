using System;
using Global.Localizations.Runtime;
using Menu.Common.Navigation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Menu.Settings.UI
{
    [DisallowMultipleComponent]
    public class SettingsView : MonoBehaviour, ISettingsView
    {
        [Inject]
        private void Construct(ILocalization localization)
        {
            _localization = localization;
        }
        
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _soundSlider;

        [SerializeField] private TMP_Text _languageText;
        [SerializeField] private Button _languageButton;
        [SerializeField] private Button _socialButton;
        
        private ITabNavigation _navigation;
        private RectTransform _transform;
        
        private ILocalization _localization;

        public ITabNavigation Navigation => _navigation;
        public RectTransform Transform => _transform;

        public float MusicValue => _musicSlider.value;
        public float SoundValue => _soundSlider.value;

        public event Action LanguageClicked;
        public event Action SocialClicked;
        
        public void SetLanguage(string language)
        {
            _languageText.text = language; 
        }

        private void Awake()
        {
            _navigation = GetComponent<ITabNavigation>();
            _transform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            _languageButton.onClick.AddListener(OnLanguageClicked);
            _socialButton.onClick.AddListener(OnSocialClicked);
        }
        
        private void OnDisable()
        {
            _languageButton.onClick.RemoveListener(OnLanguageClicked);
            _socialButton.onClick.RemoveListener(OnSocialClicked);
        }

        private void OnLanguageClicked()
        {
            LanguageClicked?.Invoke();
        }

        private void OnSocialClicked()
        {
            SocialClicked?.Invoke();    
        }
    }
}