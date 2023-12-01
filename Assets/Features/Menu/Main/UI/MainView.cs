using Common.UI.Buttons;
using GamePlay.Level.Dots.Definitions;
using Menu.Common.Navigation;
using Menu.Main.UI.DotSelections;
using UnityEngine;

namespace Menu.Main.UI
{
    [DisallowMultipleComponent]
    public class MainView : MonoBehaviour, IMainView
    {
        [SerializeField] private ModeSelection _modeSelection;
        [SerializeField] private ExtendedButton _playButton;
        [SerializeField] private DotSelection _dotSelection;
        
        private ITabNavigation _navigation;
        private RectTransform _transform;
        private IMainInterceptor _interceptor;

        public IModeSelection ModeSelection => _modeSelection;
        public ITabNavigation Navigation => _navigation;
        public RectTransform Transform => _transform;
        
        public void Construct(IMainInterceptor interceptor, IDotDefinitionsStorage dotDefinitionsStorage)
        {
            _interceptor = interceptor;
            _dotSelection.Construct(dotDefinitionsStorage);
        }

        private void Awake()
        {
            _navigation = GetComponent<ITabNavigation>();
            _transform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            _playButton.Clicked += OnPlayClicked;
        }

        private void OnDisable()
        {
            _playButton.Clicked -= OnPlayClicked;
        }
        
        private void OnPlayClicked()
        {
            _interceptor.OnPlayRequested();
        }
    }
}