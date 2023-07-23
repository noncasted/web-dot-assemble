using Common.UI.UniversalPlates.Buttons;
using UnityEngine;

namespace Menu.Main.UI.Runtime
{
    [DisallowMultipleComponent]
    public class MenuView : MonoBehaviour, IMenuView
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private GameObject _loading;

        [SerializeField] private GameObject _mainBody;
        [SerializeField] private PlayBody _playBody;
        [SerializeField] private JoinBody _joinBody;
        
        [SerializeField] private UniversalButton _playButton;

        private void Awake()
        {
            _body.SetActive(false);
        }

        private void OnEnable()
        {
            _playButton.Clicked += OnPlayClicked;
        }

        private void OnDisable()
        {
            _playButton.Clicked -= OnPlayClicked;
        }

        public void Open()
        {
            _body.SetActive(true);
            _mainBody.SetActive(true);
            _playBody.Close();
            _joinBody.Close();
        }

        public void Close()
        {
            _body.SetActive(false);
        }

        public void OnLoading()
        {
            _loading.SetActive(true);
        }

        public void CancelLoading()
        {
            _loading.SetActive(false);
        }

        private void OnPlayClicked()
        {
            _body.SetActive(false);
            _playBody.Transit();
        }
    }
}